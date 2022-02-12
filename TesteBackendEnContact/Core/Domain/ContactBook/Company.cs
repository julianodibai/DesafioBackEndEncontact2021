
using System.Collections.Generic;
using TesteBackendEnContact.Core.Interface.ContactBook.Company;
using TesteBackendEnContact.Core.Interface.ContactBook;
using TesteBackendEnContact.Core.Exceptions;
using TesteBackendEnContact.Core.Validators;

namespace TesteBackendEnContact.Core.Domain.ContactBook.Company
{
    public class Company : ICompany
    {
        public int Id { get; private set; }
        public int ContactBookId { get; private set; }
        public string Name { get; private set; }
        private List<string> _errors;

        protected Company()
        {
        }
        public Company(int id, int contactBookId, string name)
        {
            Id = id;
            ContactBookId = contactBookId;
            Name = name;
            _errors = new List<string>();
        }

        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }

        public bool Validate()
        {
            var validator = new CompanyValidator();
            var validation = validator.Validate(this);

            if(!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);
                
                throw new DomainException("Alguns campos estão invalidos, por favor corrija-os!", _errors);
            }

            return true;
        }
    }
}
