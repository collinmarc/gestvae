using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Linq;
using GestVAEcls;

namespace GestVAETU
{


    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var context = new Context())
            {
                context.Departments.Add(new Department { Name = DepartmentNames.English });

                context.SaveChanges();

                var department = (from d in context.Departments
                                  where d.Name == DepartmentNames.English
                                  select d).FirstOrDefault();

                Console.WriteLine(
                    "DepartmentID: {0} Name: {1}",
                    department.DepartmentID,
                    department.Name);
            }
        }
    }
}
