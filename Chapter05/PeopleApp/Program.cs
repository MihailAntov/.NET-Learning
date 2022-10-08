// See https://aka.ms/new-console-template for more information
using Packt.Shared;
using static System.Console;
var bob = new Person();
bob.Name ="Bob Smith";
bob.DateOfBirth = new DateTime(1965, 12, 22);
bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
bob.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon|WondersOfTheAncientWorld.MausoleumAtHalicarnassus;
WriteLine($"{bob.Name} was born on {bob.DateOfBirth:dddd, d MMMM yyyy}");
var alice = new Person
{
    Name = "Alice Jones",
    DateOfBirth = new DateTime(1998, 3, 7)
};

WriteLine($"{alice.Name} was born on {alice.DateOfBirth:dd MMM yy}");
WriteLine($"{bob.Name}'s favorite wonder is {bob.FavoriteAncientWonder}. Its integer is {(int)bob.FavoriteAncientWonder}");
WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");
var vili = new Person
{
    Name = "Vili",
    DateOfBirth = new DateTime(1990, 10, 5),
    FavoriteAncientWonder = WondersOfTheAncientWorld.LighthouseOfAlexandria,
    BucketList = (WondersOfTheAncientWorld)67
};
WriteLine($"{vili.Name}'s favorite wonder is {vili.FavoriteAncientWonder}. Her bucket list is {vili.BucketList}.");
WriteLine($"She was born on {vili.DateOfBirth:d MMMM yy}");
bob.Children.Add(new Person {Name = "Alfred"});
bob.Children.Add(new Person {Name = "Zoe"});
WriteLine($"{bob.Name} has {bob.Children.Count} children:");
for (int child = 0; child < bob.Children.Count; child++)
{
    WriteLine($"{bob.Children[child].Name}");
}
WriteLine($"{bob.Name} has {bob.Children.Count} children:");
foreach(var child in bob.Children)
{
    WriteLine($"{child.Name} is {bob.Name}'s child number {bob.Children.IndexOf(child)+1}");
}
BankAccount.InterestRate = 0.012M;
var jonesAccount = new BankAccount();
jonesAccount.AccountName = "Mrs. Jones";
jonesAccount.Balance = 2400;
WriteLine($"{jonesAccount.AccountName} earned {jonesAccount.Balance * BankAccount.InterestRate :C}");
var gerrierAccount = new BankAccount();
gerrierAccount.AccountName = "Ms. Gerrier";
gerrierAccount.Balance = 98;
WriteLine($"{gerrierAccount.AccountName} earned {gerrierAccount.Balance * BankAccount.InterestRate :C}");
WriteLine($"{bob.Name} is a {Person.Species}");
WriteLine($"{bob.Name}'s home plant is {bob.HomePlanet}");
var blankPerson = new Person();
WriteLine($"{blankPerson.Name} of {blankPerson.HomePlanet} was created at {blankPerson.Instantiated:hh:mm:ss} on a {blankPerson.Instantiated:dddd}");
WriteLine($"{blankPerson.Name}'s bucketlist includes {blankPerson.BucketList}");
var paco = new Person("Paco", "Mars");
WriteLine($"{paco.Name} of {paco.HomePlanet} was created on {paco.Instantiated:dd.m.yyyy}");
bob.WriteToConsole();
WriteLine(bob.GetOrigin());
(string, int) fruit = bob.GetFruit();
WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");
var fruitNamed = bob.GetNamedFruit();
WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}.");
var thing1 = ("Neville", 4);
WriteLine($"{thing1.Item1} has {thing1.Item2} children.");
var thing2 = (bob.Name, bob.Children.Count);
WriteLine($"{thing2.Name} has {thing2.Item2} children.");
WriteLine($"{thing2.Name} has {thing2.Count} children.");
(string FruitName, int FruitNumber) = bob.GetFruit();
WriteLine($"Deconstructed: {FruitName}, {FruitNumber}");
WriteLine(bob.SayHello());
WriteLine(bob.SayHello("Rachel"));
WriteLine(vili.SayHello("Mishko"));
var Beavis = new Person("Beavis", "WhiteRun");
WriteLine(Beavis.SayHello("Butthead"));
WriteLine(bob.OptionalParameters());
WriteLine(bob.OptionalParameters("Jump!", 98.5));
WriteLine(bob.OptionalParameters(number: 52.4, command: "Down!", active: false));
WriteLine(bob.OptionalParameters("Poke!", active: false));
int a = 10;
int b = 20;
int c = 30;
WriteLine($"Before: a = {a}, b = {b}, c = {c}");
bob.PassingParameters(a, ref b, out c);
WriteLine($"After: a = {a}, b = {b}, c = {c}");
int d = 10;
int e = 20;
WriteLine($"Before: d = {d}, e = {e}, f doesn't exist yet.");
bob.PassingParameters(d, ref e, out int f);
WriteLine($"After: d = {d}, e = {e}, f = {f}");
var sam = new Person
{
    Name = "Sam",
    DateOfBirth = new DateTime(1972, 1, 27)
};
WriteLine(sam.Origin);
WriteLine(sam.Greeting);
WriteLine(sam.Age);
sam.FavoriteIceCream = "Chocolate Fudge";
WriteLine($"{sam.Name}'s favorite ice cream is {sam.FavoriteIceCream}");
sam.FavoritePrimaryColor = "Red";
WriteLine($"{sam.Name}'s favorite primary color is {sam.FavoritePrimaryColor}");
sam.Children.Add(new Person { Name = "Charlie"});
sam.Children.Add(new Person { Name = "Ella"});
WriteLine($"{sam.Name}'s first child is {sam.Children[0].Name}");
WriteLine($"{sam.Name}'s second child is {sam.Children[1].Name}");
WriteLine($"{sam.Name}'s first child is {sam[0].Name}");
WriteLine($"{sam.Name}'s second child is {sam[1].Name}");
var harry = new Person {Name = "Harry"};
var mary = new Person { Name = "Mary" };
var jill = new Person {Name = "Jill" };
//call instance method
var baby1 = mary.ProcreateWith(harry);
//call static method
var baby2 = Person.Procreate(harry, jill);
var baby3 = harry * mary;
WriteLine($"{harry.Name} has {harry.Children.Count} children.");
WriteLine($"{mary.Name} has {mary.Children.Count} children.");
WriteLine($"{jill.Name} has {jill.Children.Count} children.");
foreach(var child in harry.Children)
{
    WriteLine($"{child.Name} is one of Harry's children.");
}
WriteLine($"{harry.Name}'s first child is {harry.Children[0].Name}.");
WriteLine($"{harry.Name}'s second child is {harry.Children[1].Name}.");
//call operator
WriteLine($"5! is {Person.Factorial(5)}");
//delegates with poking and shouting
static void Harry_Shout(object sender, EventArgs e)
{
    Person p = (Person)sender;
    WriteLine($"{p.Name} is this angry: {p.AngerLevel}");
}
harry.Shout += Harry_Shout;
harry.Poke();
harry.Poke();
harry.Poke();
harry.Poke();
Person[] people = 
{
    new Person {Name = "Simon"},
    new Person {Name = "Jenny"},
    new Person {Name = "Adam"},
    new Person {Name = "Richard"}    
};
WriteLine("Initial list of people:");
foreach (var person in people)
{
    WriteLine($"{person.Name}");
}
WriteLine("Use Person's IComparable implementation to sort:");
Array.Sort(people);
foreach (var person in people)
{
    WriteLine($"{person.Name}");
}
WriteLine("Use PersonComparer's IComparer implementation to sort:");
Array.Sort(people, new PersonComparer());
foreach (var person in people)
{
    WriteLine($"{person.Name}");
}
var t1 = new Thing();
t1.Data = 42;
WriteLine($"Thing with an integer: {t1.Process(42)}");

var t2 = new Thing();
t2.Data = "apple";
WriteLine($"Thing with a string: {t2.Process("apple")}");

var gt1 = new GenericThing<int>();
gt1.Data = 42;
WriteLine($"Generic thing with an integer: {gt1.Process(42)}");

var gt2 = new GenericThing<string>();
gt2.Data = "apple";
WriteLine($"Generic thing with a string: {gt2.Process("apple")}");

string number1 = "4";
WriteLine($"{number1} squared is {Squarer.Square<string>(number1)}");

byte number2 = 3;
WriteLine($"{number2} squared is {Squarer.Square<byte>(number2)}");

var dv1 = new DisplacementVector(3, 5);
var dv2 = new DisplacementVector(-2, 7);
var dv3 = dv1 + dv2;
WriteLine($"({dv1.X}, {dv1.Y}) + ({dv2.X}, {dv2.Y}) = ({dv3.X}, {dv3.Y})");
Employee john = new Employee
{
    Name = "John Jones",
    DateOfBirth = new DateTime(1990, 7, 28)
};
john.WriteToConsole();
john.EmployeeCode = "JJ001";
john.HireDate = new DateTime(2014, 11, 23);
WriteLine($"{john.Name} was hired on {john.HireDate:dd/MM/yy}");
WriteLine(john.ToString());
Employee aliceInEmployee = new Employee
{
    Name = "Alice", EmployeeCode = "AA123"
};
Person aliceInPerson = aliceInEmployee;
aliceInEmployee.WriteToConsole();
aliceInPerson.WriteToConsole();
WriteLine(aliceInEmployee.ToString()); 
WriteLine(aliceInPerson.ToString());
if (aliceInPerson is Employee)
{
    WriteLine($"{nameof(aliceInPerson)} IS an Employee.");
    Employee explicitAlice = (Employee)aliceInPerson;
    //safely do something with explicitAlice
}
Employee aliceAsEmployee = aliceInPerson as Employee;
if (aliceAsEmployee != null)
{
    WriteLine($"{nameof(aliceAsEmployee)} AS an Employee.");
}

try
{
     john.TimeTravel(new DateTime(1999, 12, 31));
     john.TimeTravel(new DateTime(1950, 12, 25));
     
}
catch (PersonException ex)
{
    
    WriteLine(ex.Message);
}
string email1 = "pamela@test.com";
string email2 = "ian&test.com";
WriteLine($"{email1} is a valid e-mail address: {StringExtensions.IsValidEmail(email1)}");
WriteLine($"{email2} is a valid e-mail address: {StringExtensions.IsValidEmail(email2)}");

WriteLine($"{email1} is a valid e-mail address: {email1.IsValidEmail()}");
WriteLine($"{email2} is a valid e-mail address: {email2.IsValidEmail()}");