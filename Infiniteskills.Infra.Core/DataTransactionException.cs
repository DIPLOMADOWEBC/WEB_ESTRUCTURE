using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Infra.Core
{
    public class DataTransactionException
    {
        private string GetEntityValidationErrorMessage(DbEntityValidationException e)
        {

            string entityValidationError = "";
            foreach (var eve in e.EntityValidationErrors)
            {
                entityValidationError = String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                    eve.Entry.Entity.GetType().Name, eve.Entry.State);

                foreach (var ve in eve.ValidationErrors)
                    entityValidationError += String.Format("\nProperty: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                break;
            }

            return entityValidationError;
        }
    }
}
