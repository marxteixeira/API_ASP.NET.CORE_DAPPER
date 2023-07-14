using FluentValidator;
using MxStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using MxStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using MxStore.Domain.StoreContext.Entities;
using MxStore.Domain.StoreContext.Repositories;
using MxStore.Domain.StoreContext.Services;
using MxStore.Domain.StoreContext.ValueObjects;
using MxStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, ICommandHandler<CreateCustomerCommand>,ICommandHandler<AddAddressCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;

        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            //verificar se o cpf está na base
            if (_repository.CheckDocument(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            //verificar se o email ná existe na base
            if (_repository.CheckEmail(command.Email))
                AddNotification("Email", "Este e-mail já está em uso");

            //criar so VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            //criar a entidade
            var customer = new Customer(name, document, email, command.Phone);

            //Validar entidades e VOs
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
                return new CommandResult(
                    false,
                    "Por favor, corrija os campos abaixo:",
                    Notifications);

            //persistir o cliente
            _repository.Save(customer);

            //enviar um email de boas vindas
            _emailService.Send(email.Address, "hello@email.com", "Bem vindo", "Seja bem vindo ao Balta Store!");

            //retornar o resultado para tela

            return new CommandResult(true, "Bem-vindo ao Mx Store", new {
                Id = customer.Id,
                Name = name.ToString(),
                Email = email.Address
            });
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
