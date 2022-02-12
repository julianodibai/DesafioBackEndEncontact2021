using System.Collections.Generic;
using TesteBackendEnContact.Core.Interface.ContactBook;
using TesteBackendEnContact.Core.Exceptions;
using TesteBackendEnContact.Core.Validators;

namespace TesteBackendEnContact.Core.Domain.ContactBook
{
    public class ContactBook : IContactBook
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        private List<string> _errors;

        protected ContactBook()
        {
        }
        public ContactBook(int id, string name)
        {
            Id = id;
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
            var validator = new ContactBookValidator();
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
