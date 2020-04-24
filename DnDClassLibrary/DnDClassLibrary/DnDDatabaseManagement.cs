using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace DnDClassLibrary
{
    class DnDDatabaseManagement
    {

        Hello hello;
        Movies movie = new Movies
        {

            Name = "Bad Boys",

            Year = 199

        };

        File.WriteAllText(@"C:\Users\rallo\source\repos\Dnddata\movie.json", JsonConvert.SerializeObject(movie));

            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(@"C:\Users\rallo\source\repos\Dnddata\movie.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
        serializer.Serialize(file, movie);
            }
    // read file into a string and deserialize JSON to a type
    Movies movie1 = JsonConvert.DeserializeObject<Movies>(File.ReadAllText(@"C:\Users\rallo\source\repos\Dnddata\movie.json"));

            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(@"C:\Users\rallo\source\repos\Dnddata\movie.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
    Movies movie2 = (Movies)serializer.Deserialize(file, typeof(Movies));

    string json = Json
            dynamic stuff = JObject.Parse("{ 'Name': 'Jon Smith', 'Address': { 'City': 'New York', 'State': 'NY' }, 'Age': 42 }");

    string name = stuff.Name;
    string address = stuff.Address.State;
    Console.WriteLine(name);
            Console.WriteLine(address);
    }




