using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IL17DusanKrsmanovic2816.DataLayer;

namespace IL17DusanKrsmanovic2816.BusinessLayer
{
   public class Logic
    {
        private AdventureWorks2012Entities database = new AdventureWorks2012Entities();

        public List<EmpInfo> getEmployee()
        {
            IEnumerable<EmpInfo> ieEmpInfo = from person in this.database.People
                                             join emp in this.database.Employees
                                             on person.BusinessEntityID equals emp.BusinessEntityID
                                             select new EmpInfo
                                             {
                                                 ID = emp.BusinessEntityID,
                                                 ImePrezime = person.FirstName + " " + person.LastName
                                             };
            return ieEmpInfo.ToList();
        }
        public List<EmpInfoPlus> getEmpInfoPlus(int id)
        {
            IEnumerable<EmpInfoPlus> ieInfoPlus = from person in this.database.People
                                                  join emp in this.database.Employees
                                                  on person.BusinessEntityID equals emp.BusinessEntityID
                                                  join dep in this.database.EmployeeDepartmentHistories
                                                  on emp.BusinessEntityID equals dep.BusinessEntityID
                                                  join salary in this.database.EmployeePayHistories
                                                  on emp.BusinessEntityID equals salary.BusinessEntityID
                                                  join dep1 in this.database.Departments
                                                  on dep.DepartmentID equals dep1.DepartmentID
                                                  where emp.BusinessEntityID == id
                                                  select new EmpInfoPlus
                                                  {
                                                      ID = emp.BusinessEntityID,
                                                      Posao = emp.JobTitle,
                                                      DatumZaposlenja = emp.HireDate,
                                                      Rata = salary.Rate,
                                                      UčestalostIsplate = salary.PayFrequency,
                                                      ImeOdeljenja = dep1.Name,
                                                      ImeGrupe = dep1.GroupName,
                                                      Odmor = emp.VacationHours,
                                                      Bolovanje = emp.SickLeaveHours


                                                  };
            return ieInfoPlus.ToList();
        }
        public List<EmpInfoPlus> getEmpInfoPlus()
        {
            IEnumerable<EmpInfoPlus> ieInfoPlus = from person in this.database.People
                                                  join emp in this.database.Employees
                                                  on person.BusinessEntityID equals emp.BusinessEntityID
                                                  join dep in this.database.EmployeeDepartmentHistories
                                                  on emp.BusinessEntityID equals dep.BusinessEntityID
                                                  join salary in this.database.EmployeePayHistories
                                                  on emp.BusinessEntityID equals salary.BusinessEntityID
                                                  join dep1 in this.database.Departments
                                                  on dep.DepartmentID equals dep1.DepartmentID
                                                  
                                                  select new EmpInfoPlus
                                                  {
                                                      ID = emp.BusinessEntityID,
                                                      Posao = emp.JobTitle,
                                                      DatumZaposlenja = emp.HireDate,
                                                      Rata = salary.Rate,
                                                      UčestalostIsplate = salary.PayFrequency,
                                                      ImeOdeljenja = dep1.Name,
                                                      ImeGrupe = dep1.GroupName,
                                                      Odmor = emp.VacationHours,
                                                      Bolovanje = emp.SickLeaveHours


                                                  };
            return ieInfoPlus.ToList();
        }
        public List<EmpInfoJob> getEmpInfoJob(int id)
        {
            IEnumerable<EmpInfoJob> ieEmpJob = from emp in this.database.Employees
                                               join people in this.database.People
                                               on emp.BusinessEntityID equals people.BusinessEntityID
                                               join email in this.database.EmailAddresses
                                               on people.BusinessEntityID equals email.BusinessEntityID
                                               join phone in this.database.PersonPhones
                                               on people.BusinessEntityID equals phone.BusinessEntityID
                                               join type in this.database.PhoneNumberTypes
                                               on phone.PhoneNumberTypeID equals type.PhoneNumberTypeID
                                               join depHist in this.database.EmployeeDepartmentHistories
                                               on emp.BusinessEntityID equals depHist.BusinessEntityID
                                               join dep in this.database.Departments
                                               on depHist.DepartmentID equals dep.DepartmentID
                                               join shift in this.database.Shifts
                                               on depHist.ShiftID equals shift.ShiftID
                                               where emp.BusinessEntityID == id

                                               select new EmpInfoJob
                                               {
                                                   ID = emp.BusinessEntityID,
                                                   Telefon = phone.PhoneNumber,
                                                   Email = email.EmailAddress1,
                                                   Početak = shift.StartTime,
                                                   Kraj = shift.EndTime,
                                                   Smena = shift.Name,
                                                   TipTelefona = type.Name

                                               };
            return ieEmpJob.ToList();
                                                                            

        }
        public List<CustomerInfo> getCustInfo()
        {
            IEnumerable<CustomerInfo> ieCust = from peo in this.database.People
                                               join cust in this.database.Customers
                                               on peo.BusinessEntityID equals cust.PersonID
                                               join creditcardhis in this.database.PersonCreditCards
                                               on peo.BusinessEntityID equals creditcardhis.BusinessEntityID
                                               join card in this.database.CreditCards
                                               on creditcardhis.CreditCardID equals card.CreditCardID
                                               select new CustomerInfo
                                               {
                                                   Ime = peo.FirstName,
                                                   Prezime = peo.LastName,
                                                   KreditnaKartica = card.CardNumber,
                                                   TipKartice = card.CardType
                                               };
            return ieCust.ToList();
        }
        public List <CustomerInfo1> getInfo()
        {
            IEnumerable<CustomerInfo1> ieCust = from peple in this.database.People
                                                join cust in this.database.Customers
                                              on peple.BusinessEntityID equals cust.PersonID
                                                select new CustomerInfo1
                                                {
                                                    ID = cust.PersonID,
                                                    ImePrezime = peple.FirstName + " " + peple.LastName
                                                };
            return ieCust.ToList();
                                                                  
        }
        public List<CustomerInfoCredit> getCredit(int id)
        {
            IEnumerable<CustomerInfoCredit> iecrdit = from peo in this.database.People
                                                      join cust in this.database.Customers
                                                      on peo.BusinessEntityID equals cust.PersonID
                                                      join creditcardhis in this.database.PersonCreditCards
                                                      on peo.BusinessEntityID equals creditcardhis.BusinessEntityID
                                                      join card in this.database.CreditCards
                                                      on creditcardhis.CreditCardID equals card.CreditCardID
                                                      where cust.PersonID == id
                                                      select new CustomerInfoCredit
                                                      {
                                                          ID = cust.PersonID,
                                                          KreditnaKartica = card.CardNumber,
                                                          TipKartice = card.CardType
                                                      };
            return iecrdit.ToList();
        }
        public List<CustomerInfoCredit> getCreditAll()
        {
            IEnumerable<CustomerInfoCredit> iecrdit = from peo in this.database.People
                                                      join cust in this.database.Customers
                                                      on peo.BusinessEntityID equals cust.PersonID
                                                      join creditcardhis in this.database.PersonCreditCards
                                                      on peo.BusinessEntityID equals creditcardhis.BusinessEntityID
                                                      join card in this.database.CreditCards
                                                      on creditcardhis.CreditCardID equals card.CreditCardID
                                                      
                                                      select new CustomerInfoCredit
                                                      {
                                                         
                                                          KreditnaKartica = card.CardNumber,
                                                          TipKartice = card.CardType
                                                      };
            return iecrdit.ToList();
        }
        public List<CustomerInfoCredit2> getCrd(int id)
        {
            IEnumerable<CustomerInfoCredit2> iecrd = from peo in this.database.People
                                                     join cust in this.database.Customers
                                                     on peo.BusinessEntityID equals cust.PersonID
                                                     join store in this.database.Stores
                                                     on cust.StoreID equals store.BusinessEntityID
                                                     where cust.PersonID == id
                                                     select new CustomerInfoCredit2
                                                     {
                                                         ID = cust.PersonID,
                                                         Store = store.Name,
                                                         Demografija = store.Demographics
                                                     };
            return iecrd.ToList();
        }
    }
}
