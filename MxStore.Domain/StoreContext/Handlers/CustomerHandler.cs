using FluentValidator;
using MxStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using MxStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using MxStore.Domain.StoreContext.Entities;
using MxStore.Domain.StoreContext.ValueObjects;
using MxStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MxStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, ICommandHandler<CreateCustomerCommand>,ICommandHandler<AddAddressCommand>
    {
        public ICommandResult Handle(CreateCustomerCommand command)
        {
            //verificar se o cpf está na base

            //verificar se o email ná existe na base

            //criar so VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            //criar a entidade
            var customer = new Customer(name, document, email, command.Phone);

            //persistir o cliente
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            //enviar um email de boas vindas

            //retornar o resultado para tela

            return new CreateCustomerCommandResult(Guid.NewGuid(), name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
