using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {

            Exercise1_1("employee.xml");

            // これは確認用
            Console.WriteLine(File.ReadAllText("employee.xml"));
            Console.WriteLine();

            Exercise1_2("employees.xml");
            Exercise1_3("employees.xml");
            Console.WriteLine();

            Exercise1_4("employees.json");

            // これは確認用
            //Console.WriteLine(File.ReadAllText("employees.json"));
        }

        private static void Exercise1_1(string v) {
            var emp = new Employee() {
                Id = 1001,
                Name = "阿部 隆",
                HireDate = new DateTime(2003, 07, 01),
            };

            using (var writer = XmlWriter.Create(v)) {
                var serializer = new XmlSerializer(emp.GetType());
                serializer.Serialize(writer, emp);
            }
            using (var reader = XmlReader.Create(v)) {
                var serializer = new XmlSerializer(emp.GetType());
                emp = (Employee)serializer.Deserialize(reader);
            }
        }

        private static void Exercise1_2(string v) {
            var emps = new Employee[] {
                new Employee {
                    Id = 1001,
                    Name = "阿部 隆",
                    HireDate = new DateTime(2003, 07, 01),
                },
                new Employee {
                    Id = 1002,
                    Name = "加藤 明久",
                    HireDate = new DateTime(2009, 08, 07),
                },
                new Employee {
                    Id = 1002,
                    Name = "斎藤 流星",
                    HireDate = new DateTime(2012, 12, 31),
                },
            };

            using (var writer = XmlWriter.Create(v)) {
                var serializer = new DataContractSerializer(emps.GetType());
                serializer.WriteObject(writer, emps);
            }
            Console.WriteLine(File.ReadAllText(v));
            Console.WriteLine();

        }

        private static void Exercise1_3(string v) {
            using (var reader = XmlReader.Create(v)) {
                var serializer = new DataContractSerializer(typeof(Employee[]));
                var emps = serializer.ReadObject(reader);
            }
            Console.WriteLine(File.ReadAllText(v));
            Console.WriteLine();

        }

        private static void Exercise1_4(string v) {
            var emps = new Employee[] {
                new Employee {
                    Id = 1001,
                    Name = "阿部 隆",
                    HireDate = new DateTime(2003, 07, 01),
                },
                new Employee {
                    Id = 1002,
                    Name = "加藤 明久",
                    HireDate = new DateTime(2009, 08, 07),
                },
                new Employee {
                    Id = 1002,
                    Name = "斎藤 流星",
                    HireDate = new DateTime(2012, 12, 31),
                },
            };

            using (var stream = new FileStream(v, FileMode.Create, FileAccess.Write)) {
                var serializer = new DataContractJsonSerializer(emps.GetType());
                serializer.WriteObject(stream, emps);
            };

            Console.WriteLine(File.ReadAllText(v));
            Console.WriteLine();
        }
    }
}
