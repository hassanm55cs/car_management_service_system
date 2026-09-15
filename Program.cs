using Car_services.Data;
using Car_services.Enums;
using Car_services.Model;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Diagnostics;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;


class Program
{
    class Student
    {
        public string Name { get; set; }
        public List<string> Courses { get; set; }
    }
    public delegate void test1();

    class student
    {


        Func<int, int> e = cc;
        public delegate void test();
        public event test process;
        public string Name { get; set; }
        public int age { get; set; }

        public void talk()
        {
            process();
        }
        public void hey()

        {
            Console.WriteLine("say hay");
        }
        public void hello()
        {
            Console.WriteLine("hello");
        }
        public void hel(test bb)
        {
            Console.WriteLine("hello");
            bb();
        }


    }
    static T run<T, u>(T x, u y)
    {
        return x;
    }
    static T cc<T>(T x)
    {
        return x;
    }
    static void naaa()
    {
        Console.WriteLine("say naaaa");
    }
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        test1 cc = naaa;
        test1 c1 = naaa;

        var st = new student();
        st.hel(naaa);
        st.process += st.hello;
        st.process += st.hey;
        st.talk();
        Console.WriteLine("=================================================");


        var context = new ApplicationDbContext();

        var Cars = context.Car
      .Select(c => new { carmodel = c.Model, fueltype = c.Fuel_Type, date = c.manufactuare_date, company = c.Car_Company, price = c.PriceInEgp })
      //.Where(c => c.date > new DateOnly(2022, 2, 1) && c.carmodel != "magenta")
      .GroupBy(c => c.company)
      .Select(g => new
      {
          carmodel = g.Key,
          cars = g.OrderBy(x => x.date).ToList(),
          sumeofpriccebycompany = g.Sum(m => m.price)

      }

);
        var customers = context.Car
            .GroupBy(c => c.Customer_Id)
            .Select(g => new
            {
                customer = g.Key,
                cars = g.OrderBy(g => g.manufactuare_date).ToList(),
                // you must get here all cars as a list as the group will return a list of every fillter by the group by and you can order it by any property you want
                xx = g.Where(x => x.No_of_cylinders >= 4).ToList()// here you can get all elemnts of the group by without any ordering or filtering

            });


        var count2 = context.Car.AsEnumerable().CountBy(c => $"no of cylinders{c.No_of_cylinders}- color is {c.Color}");//make count as a group by but easier 


        foreach (var i in count2)
        {
            Console.WriteLine($"{i.Key} and the count is {i.Value}");
        }


        var max = context.Car.AsEnumerable().MaxBy(c => $" the price is {c.PriceInEgp}");
        if (max != null)
        {
            //Console.WriteLine($"the car compamny: {max.Car_Company} the modle {max.Model} the max in price is ={max.PriceInEgp}");
            Console.WriteLine(max.Car_Company);
        }

        var sum = context.Car.GroupBy(c => c.Car_Company)
      .Select(c => new
      {
          carcompany = c.Key,
          sum = c.Sum(m => m.PriceInEgp),// here we get the sum of the list of the group by [note:sum must work on list]
                                         // "car company" and we can use any property we want to sum it up
          max = c.OrderByDescending(m => m.PriceInEgp).FirstOrDefault()
      }).OrderByDescending(c => c.sum);


        foreach (var i in sum)

        {

            Console.WriteLine($"model: {i.carcompany} sum={i.sum} max in the list is {i.max.Fuel_Type}");

        }


        //foreach (var i in Cars)
        //{
        //    Console.WriteLine($"carmodel: {i.carmodel}");
        //    Console.WriteLine($"pricebymodel: {i.sumeofpriccebycompany}");
        //    foreach (var car in i.cars)
        //    {
        //        Console.WriteLine($" fueltype: {car.fueltype}, date: {car.date}");

        //    }

        //}

        //foreach (var i in customers)
        //{
        //    Console.WriteLine($"customer: {i.customer}");
        //    foreach (var j in i.cars)
        //    {
        //        Console.WriteLine($" car company:{j.Car_Company},carmodel: {j.Model}, plate: {j.Licences_Plate}");

        //    }

        //}

        var vv = context.Car.AsEnumerable().CountBy(m => m.Engine_type);
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        foreach (var i in vv)
        {
            Console.WriteLine($"Engine type: {i.Key} and the count is {i.Value}");
        }
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        var bb = context.Car.GroupBy(c => c.Engine_type)
            .Select(k => new
            {
                Engine_type = k.Key,
                count = k.Count(),
                cars = k.ToList()
            });
        foreach (var i in bb)
        {
            Console.WriteLine($"Engine type: {i.Engine_type} and the count is {i.count}");
            foreach (var j in i.cars)
            {
                Console.WriteLine($" car company:{j.Car_Company},carmodel: {j.Model}, plate: {j.Licences_Plate}, Engine_Type{j.Engine_type} ");
            }
        }
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        var test = context.Car.GroupBy(c => c.Fuel_Type)
            .Select(v => new
            {
                Fuel_Type = v.Key,
                list = v.ToList(),


            });
        foreach (var i in test)
        {
            Console.WriteLine($"Fuel type: {i.Fuel_Type} and the count is {i.list.Count}");
            foreach (var j in i.list)
            {
                Console.WriteLine($" car company:{j.Car_Company},carmodel: {j.Model}, plate: {j.Licences_Plate}, Fuel_Type{j.Fuel_Type} ");
            }
        }
        string[] cars = { "BMW", "Audi", "Mercedes" };

        string result = string.Join(" ", cars);


        Console.WriteLine(result);
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        var n = context.Car.AsEnumerable().DistinctBy(c => new { c.Color });
        foreach (var i in n)
        {
            Console.WriteLine($"car company:{i.Car_Company},carmodel: {i.Model}, plate: {i.Licences_Plate}, Fuel_Type{i.Fuel_Type} ");
        }

        var m = context.Car
      .AsEnumerable()
      .AggregateBy(
          c => c.Car_Company,
          seed: new List<string>(),
          (b, v) =>
          {


              return [.. b, v.manufactuare_date.ToString()];
          }
      );
        Console.WriteLine("-----------------------------------------------------------------------------------------------");

        foreach (var i in m)
        {
            Console.WriteLine($"car company:{i.Key}");
            foreach (var j in i.Value)
            {
                Console.WriteLine($"manufactuare_date: {j}");
            }
        }
        var minb = context.Car.AsEnumerable().Select(c => c.PriceInEgp).Min();
        var mii = context.Car.GroupBy(c => c.Car_Company)
            .Select(b => new
            {
                carcompany = b.Key,
                minprice = b.Select(b => b.PriceInEgp).Min(),
                date = b.Where(n => n.manufactuare_date < new DateOnly(2022, 1, 1)).Select(b => b.manufactuare_date)
            });
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        Console.WriteLine("-----------------------------------------------------------------------------------------------");

        foreach (var i in mii)
        {
            Console.WriteLine($"car company:{i.carcompany} min price is {i.minprice}");
            foreach (var j in i.date)
            {
                Console.WriteLine($"manufactuare_date: {j}");
            }



        }
        Console.WriteLine("-----------------------------------------------------------------------------------------------mmmm");
        var lookup = context.Car.ToList();
        var uni = context.Car.ToList();
        var list = lookup.IntersectBy(uni.Select(v => v.No_of_cylinders), v => v.No_of_cylinders);
        foreach (var i in list)
        {
            Console.WriteLine($"car company:{i.Car_Company} no of cylinders:{i.No_of_cylinders}");

        }
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        var bmw = context.Car.FirstOrDefault(c => c.Car_Company == "bmw");
        var car1 = context.Car.ToList();
        var result1 = car1.DefaultIfEmpty(bmw);
        Console.WriteLine($" company:{bmw.Car_Company}, model:{bmw.Model}");
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        Console.WriteLine($"the result is equla:{result1.ElementAt(1)}");
        Console.WriteLine("-----------------------------------------------------------------------------------------------\\\\\\\\\\\\");

        var xi = context.Car.AsEnumerable().AggregateBy(c => c.Car_Company, seed: new List<string>(), (a, b) =>
        {
            List<string> x = new List<string>();
            x.AddRange(a);//here we take all value inside the list b to make sure i have everything from the previous 
            x.Add(b.manufactuare_date.ToString());//here we add the new value of the a 



            return x;//return the prev and the current 
        }
        );
        Console.WriteLine("-----------------------------------------------------------------------------------------------suiiiiijjjj");


        foreach (var i in xi)
        {
            Console.WriteLine($"the key is {i.Key}");
            foreach (var j in i.Value)
            {
                Console.WriteLine($"the value is{j}");
            }
        }
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        foreach (var customer in customers)
        {
            Console.WriteLine($"the key:{customer.customer}");
            foreach (var c in customer.xx)
            {
                Console.WriteLine($"the car company:{c.manufactuare_date}, the model is {c.Model}");
            }
        }
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        //here how to make the join and the selection and the group by in the same query 
        var join = from Customer in context.Customer
                   join car in context.Car
                 on Customer.CustomerId equals car.Customer_Id

                   select new
                   {
                       cutomer_id = Customer.CustomerId,
                       name = Customer.Full_name,
                       plate = car.Licences_Plate,
                       car_model = car.Model,
                       company = car.Car_Company,
                       date = car.manufactuare_date
                   } into all
                   group all by all.cutomer_id into g
                   orderby g.Key descending
                   select (new
                   {
                       cutomer_id = g.Key,
                       cars = g.OrderByDescending(c => c.date).ToList()
                   })

                   ;



        foreach (var i in join)
        {
            Console.WriteLine($"the group by: {i.cutomer_id}");
            foreach (var j in i.cars)
            {
                Console.WriteLine($"the name is {j.name}, the plate is {j.plate}, the car model is {j.car_model}, the company is {j.company}");
            }
        }
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        var join2 = from Customer in context.Customer
                    join car in context.Car
                    on Customer.CustomerId equals car.Customer_Id
                    orderby Customer.CustomerId descending
                    select (new
                    {
                        cutomer_id = Customer.CustomerId,
                        name = Customer.Full_name,
                        plate = car.Licences_Plate,
                        car_model = car.Model,
                        company = car.Car_Company,
                        date = car.manufactuare_date
                    });

        foreach (var i in join2)
        {
            Console.WriteLine($"the cutomer_id: {i.cutomer_id}, the name is {i.name}\n, the plate is {i.plate}, the car model is {i.car_model}\n," +
                $" the company is {i.company}\n, the date is {i.date}\n");
        }
        var join3 = context.Car.Join(context.Customer, c => c.Customer_Id, v => v.CustomerId, (m, k) => new
        {
            name = k.Full_name,
            id = k.CustomerId,
            plate = m.Licences_Plate,
            company = m.Car_Company,

        });
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        foreach (var i in join3)
        {
            Console.WriteLine($"id:{i.id},name:{i.name}, company:{i.company}, palte{i.plate}");
        }
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        Console.WriteLine("-----------------------------------------------------------------------------------------------//");
        var join4 = from Customer in context.Customer
                    join c6 in context.Car
                    on Customer.CustomerId equals c6.Customer_Id

                    join service in context.service
                    on c6.Licences_Plate equals service.CarId
                    into carcompany
                    select (new
                    {
                        id = Customer.CustomerId,
                        name = Customer.Full_name,
                        //car_palte=c6.Licences_Plate,
                        //car_company=c6.Car_Company,
                        mod = carcompany

                    });
        var join44 = join4.GroupBy(g => new { id = g.id, name = g.name }).Select(g => new { id = g.Key.id, fullname = g.Key.name, vechiles = g.ToList() });

        foreach (var i in join4)
        {
            Console.WriteLine($"id:{i.id},name: {i.name}");
            //foreach (var j in i.mod)
            //{
            //    Console.WriteLine($"serviceid:{j.serviceId},emp_id:{j.EmployeeId},branchofservice:{j.BranchId}");
            //}


        }
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        Console.WriteLine("-----------------------------------------------------------------------------------------------");
        foreach (var i in join44)
        {
            Console.WriteLine($"id: {i.id} name:{i.fullname}");
            foreach (var j in i.vechiles)
            {
                //Console.WriteLine($"customername:{j.name}");
                foreach (var k in j.mod)
                {
                    Console.WriteLine($"service_id:{k.serviceId}carId:{k.CarId},emp_id:{k.EmployeeId},branchofservice:{k.BranchId}");
                }
            }
        }
        Console.WriteLine("-----------------------------------------------------------------------------------------------\\\\");

        var joinrc = from Customer in context.Customer
                     join car in context.Car
                     on Customer.CustomerId equals car.Customer_Id
                     join service in context.service
                     on car.Licences_Plate equals service.CarId
                     select (new
                     {
                         id = Customer.CustomerId,
                         fullname = Customer.Full_name,
                         plate = car.Licences_Plate,
                         service = service.serviceId,
                         emp_id = service.EmployeeId,
                         model = car.Model,

                     }) into all
                     group all by new { all.id, all.fullname, all.plate };

        //for( int i = 0;i < joinrc.Count(); i++)
        //{
        //    Console.WriteLine($"customerid:{joinrc.ElementAt(i).Key.id},name:{joinrc.ElementAt(i).Key.fullname} plate{joinrc.ElementAt(i).Key.plate}");
        //    for(int j = 0; j < joinrc.ElementAt(i).Count(); j++)
        //    {
        //        Console.WriteLine($"serviceid:{joinrc.ElementAt(i).ElementAt(j).service},emp_id:{joinrc.ElementAt(i).ElementAt(j).emp_id},model:{joinrc.ElementAt(i).ElementAt(j).model}");
        //    }

        //}
        Console.WriteLine("-----------------------------------------------------------------------------------------------\\\\");
        Console.WriteLine("-----------------------------------------------------------------------------------------------\\\\");

        foreach (var v in joinrc)
        {
            Console.WriteLine(v);
            Console.WriteLine($"customerid:{v.Key.id},name:{v.Key.fullname} plate{v.Key.plate}");
            foreach (var j in v)
            {
                Console.WriteLine($"serviceid:{j.service},emp_id:{j.emp_id},model:{j.model}");
            }
        }
        var suii = context.Car.GroupBy(c => c.Car_Company);
        foreach (var i in suii)
        {
            Console.WriteLine($"the car company is {i.Key}");
            foreach (var j in i)
            {
                Console.WriteLine($"the model is {j.Car_Company}, the plate is {j.Licences_Plate}, the fuel type is {j.Fuel_Type}");
            }
        }
        Console.WriteLine("-----------------------------------------------------------------------------------------------\\\\");
        Console.WriteLine("-----------------------------------------------------------------------------------------------\\\\");
        var join7 = context.Customer.GroupJoin(context.Car, c => c.CustomerId, v => v.Customer_Id, (customer, car) =>
        new

        {
            customerid = customer.CustomerId,
            customername = customer.Full_name,
            customerEmail = customer.Email,

            cars = car.ToList()
        });
        foreach(var customers1 in join7)
        {
            Console.WriteLine($"the id :{customers1.customerid},the customer name:{customers1.customername},customerEmail:{customers1.customerEmail}");
            foreach(var cars1 in customers1.cars)
            {
                Console.WriteLine($"the car company:{cars1.Car_Company},the manafacture date:{cars1.manufactuare_date},car palte:{cars1.Licences_Plate},carmodel:{cars1.Model}");
          
            }
        }
        Console.WriteLine("-----------------------------------------------------------------------------------------------\\\\");
        Console.WriteLine("-----------------------------------------------------------------------------------------------\\\\");
        var testc = context.Car.AsEnumerable().GroupBy(c => c.No_of_cylinders, (c, m) => 
        new
        {
            key=c,
            cars=m

        });
        foreach(var c in testc)
        {
            Console.WriteLine($"the group by key is:{c.key}");
            foreach(var carsc in c.cars)
            {
                Console.WriteLine($"the car cpmpany :{carsc.Car_Company},model:{carsc.Model}");
            }
        }
        Console.WriteLine("-----------------------------------------------------------------------------------------------\\\\");
        Console.WriteLine("-----------------------------------------------------------------------------------------------\\\\jk");
        var ee = from cutomers1 in context.Customer
                 join Cars1 in context.Car
                 on cutomers1.CustomerId equals Cars1.Customer_Id
                 into gm
                 select (new
                 {
                     key= cutomers1.CustomerId,
                     value =gm.ToList(),
                     

                 });
        foreach(var i in ee)
        {
            Console.WriteLine($"the key is :{i.key}");
            foreach(var j in i.value)
            {
                Console.WriteLine($"the comp:{j.Car_Company}");
            }
        }
        Console.WriteLine("-----------------------------------------------------------------------------------------------\\\\");
        Console.WriteLine("-----------------------------------------------------------------------------------------------\\\\");
        var students = new List<Student>
{
    new Student
    {
        Name = "Mostafa",
        Courses = new List<string> { "C#", "SQL" }
    },

    new Student
    {
        Name = "Ahmed",
        Courses = new List<string> { "Java", "Python" }
    },

    new Student
    {
        Name = "Omar",
        Courses = new List<string> { "C#", "JavaScript" }
    }
};
        var select = students.SelectMany(c => c.Courses);
        Console.WriteLine("-----------------------------------------------------------------------------------------------\\\\");

        foreach (var student in select)
        {
            Console.WriteLine($"the key is :{student},list:{student}");

        }
        Console.WriteLine("-----------------------------------------------------------------------------------------------\\\\");
        Console.WriteLine("-----------------------------------------------------------------------------------------------\\\\");

        var left = context.Customer.LeftJoin(context.Car, c => c.CustomerId, v => v.Customer_Id, (customer, car) => new
        {
            id=customer.CustomerId,
            name=customer.Full_name,
            carmodel=car.Model,

        });
        var coo = context.Car.AsEnumerable().CountBy(c => c.Car_Company);
        foreach (var i in coo)
        {
            Console.WriteLine($"key:{i.Key},value:{i.Value}");

        }
        Console.WriteLine("-----------------------------------------------------------------------------------------------\\\\");
        Console.WriteLine("-----------------------------------------------------------------------------------------------\\\\");
        var xv = context.Car.ToList();

        var reverse = context.Car.ToList();
         xv.AddRange(reverse);
        //important fo rcalc the necxt service km for a car based on the current km and the service interval is 10000 km
        int currentKm = 28577;

        int nextServiceKm = ((currentKm / 10000) + 1) * 10000;

        Console.WriteLine(nextServiceKm);
        //foreach(var i in reverse)
        //{
        //    Console.WriteLine($"the id:{i.First},{i.Second}");
        //}
    }


}

