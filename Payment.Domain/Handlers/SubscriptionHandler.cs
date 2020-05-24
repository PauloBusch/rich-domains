using Flunt.Notifications;
using Flunt.Validations;
using Payment.Domain.Commands;
using Payment.Domain.Repositories;
using Payment.Domain.Services;
using Payment.Domain.ValueObjects;
using Payment.Shared.Commands;
using Payment.Shared.Handlers;
using PaymentContext.Domain.Entities;
using System;

namespace Payment.Domain.Handlers
{
    public class SubscriptionHandler :
        Notifiable,
        IHandler<CreateBoletoSubscriptionCommand>,
        IHandler<CreatePayPalSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;
        private readonly IEmailService _emailService;

        public SubscriptionHandler(
            IStudentRepository repository,
            IEmailService emailService
        ) {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handler(CreateBoletoSubscriptionCommand command)
        {
            // Fast validation
            command.Validate();
            if (command.Invalid) { 
                AddNotifications(command);
                return new CommandResult(false, "Invalid paramters");
            }

            // Verificar documentos cadastrados
            if (_repository.DocumentExists(command.PayerDocument)) 
                  AddNotification("Document", "Current document already exists");

            // Verificar se email está cadastrados
            if (_repository.EmailExists(command.Email))
                AddNotification("Email", "Current email already exists");

            // Gerar os VDs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.PayerDocument, command.PayerDocumentType);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

            // Gerar as entidades
            var studant = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddDays(30));
            var payment = new BoletoPayment(command.BarCode, command.BoletoNumber, command.PaidDate, command.ExpireDate, command.Total, command.TotalPaid, command.PayerDocument, document, address, email);
            
            // Relacionamentos
            subscription.AddPayment(payment);
            studant.AddSubscription(subscription);

            // agrupar as validações
            AddNotifications(document, email, address, address, studant, subscription, payment);

            // Checar as validações
            if (Invalid)
                return new CommandResult(false, "Invalid parameters");

            // Salvar as informações
            _repository.CreateSubscription(studant);

            // Enviar email de boas vindas
            _emailService.Send(studant.Name.ToString(), studant.Email.Address, "Bem-vindo", "Body");

            // Retornar informações
            return new CommandResult(true, "Success in signature");
        }

        public ICommandResult Handler(CreatePayPalSubscriptionCommand command)
        {      
            // Fast validation
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Invalid paramters");
            }

            // Verificar documentos cadastrados
            if (_repository.DocumentExists(command.PayerDocument))
                AddNotification("Document", "Current document already exists");

            // Verificar se email está cadastrados
            if (_repository.EmailExists(command.Email))
                AddNotification("Email", "Current email already exists");

            // Gerar os VDs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.PayerDocument, command.PayerDocumentType);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

            // Gerar as entidades
            var studant = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddDays(30));
            var payment = new PayPalPayment(command.TransactinCode, command.PaidDate, command.ExpireDate, command.Total, command.TotalPaid, command.PayerDocument, document, address, email);

            // Relacionamentos
            subscription.AddPayment(payment);
            studant.AddSubscription(subscription);

            // agrupar as validações
            AddNotifications(document, email, address, address, studant, subscription, payment);

            // Checar as validações
            if (Invalid)
                return new CommandResult(false, "Invalid parameters");

            // Salvar as informações
            _repository.CreateSubscription(studant);

            // Enviar email de boas vindas
            _emailService.Send(studant.Name.ToString(), studant.Email.Address, "Bem-vindo", "Body");

            // Retornar informações
            return new CommandResult(true, "Success in signature");
        }
    }
}
