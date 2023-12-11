using FSCTMM_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FSCTMM_HFT_2023241.Client
{
     class CrudServices
    {
        private RestService Rest;

        public CrudServices(RestService rest)
        {
            this.Rest = rest;
        }


        public void Create<T>()
        {
            var properties = typeof(T).GetProperties().Where(p => p.GetAccessors().All(a => !a.IsVirtual) && p.Name != "Id");
            T instance = (T)Activator.CreateInstance(typeof(T));

            foreach (var property in properties)
            {
                Console.Write($"{property.Name}= ");
                string input = Console.ReadLine();

                if (property.PropertyType == typeof(int))
                {
                    property.SetValue(instance, int.Parse(input));
                }
                else
                {
                    property.SetValue(instance, input);
                }
            }

            Rest.Post(instance, typeof(T).Name);
        }


        public void List<T>()
        {


            var properties = typeof(T).GetProperties().Where(p => p.GetAccessors().All(a => !a.IsVirtual));
            
            var items = Rest.Get<T>(typeof(T).Name);
            
            foreach (var property in properties)
            {
                Console.Write($"{property.Name}\t");
            }
            Console.Write("\n");
            foreach (var item in items)
            {
                foreach (var property in properties)
                {
                    Console.Write($"{property.GetValue(item)}\t");
                }
                Console.Write("\n");
            }
            Console.ReadLine();
        }


        public void Update<T>()
        {
            Console.WriteLine("Enter the Id to update:  ");
            int id = int.Parse(Console.ReadLine());
            var instance = Rest.Get<T>(id, typeof(T).Name);
            var properties = typeof(T).GetProperties().Where(p => p.GetAccessors().All(a => !a.IsVirtual) && p.Name != "Id");
            foreach (var property in properties)
            {
                Console.Write($"New: {property.Name} Old: {property.GetValue(instance)}=  ");
                string input = Console.ReadLine();
                if (property.PropertyType == typeof(int))
                {
                    property.SetValue(instance, int.Parse(input));
                }
                else if(property.PropertyType == typeof(string)) 
                {
                    property.SetValue(instance, input);
                }
            }
            
            Rest.Put(instance, typeof(T).Name);
         
        }

        public void Delete<T>()
        {
            Console.WriteLine("Enter the Id to delete: ");
            
            int id = int.Parse(Console.ReadLine());

            Rest.Delete(id, typeof(T).Name);
        }


    }
}
