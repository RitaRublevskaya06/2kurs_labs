using System.Reflection;

namespace Lab11
{
    /* Для изучения .NET Reflection API напишите статический класс Reflector, который собирает информацию и будет содержать методы выполняющие исследования класса (принимают в 
    качестве параметра имя класса) и записывающие информацию в файл (формат тестовый, json или xml):*/
    public static class Reflector
    {
        private static StreamWriter? _s;

        //a. Определение имени сборки, в которой определен класс
        public static void GetNameOfTheAssembly(string? className)
        {
            _s = new StreamWriter(@"D:\Univer\2 kurs\OOP\Lab_11\Lab_11\ClassInfo.txt", true);
            Type? currentClass = Type.GetType(className!, true, true);

            string assemblyName = currentClass!.Assembly.ToString();
            _s.WriteLine("*********************************************************************************");
            _s.WriteLine("*********************************************************************************");
            _s.WriteLine($"Имя класса: {className}. Имя сборки: {assemblyName}");
            _s.WriteLine("-------------------------------------------------");
            _s.Close();
        }

        //b. есть ли публичные конструкторы;
        public static void IsTherePublicConstructor(string? className)
        {
            _s = new StreamWriter(@"D:\Univer\2 kurs\OOP\Lab_11\Lab_11\ClassInfo.txt", true);
            Type? currentClass = Type.GetType(className!, true, true);

            foreach (var constructor in currentClass!.GetConstructors(BindingFlags.Public | BindingFlags.Instance))
            {
                _s.WriteLine(constructor.IsPublic ? $"\nВ классе {className} есть публичный конструктор.\n" : $"\nВ классе {className} нет публичных конструкторов.\n");
            }
            _s.WriteLine("-------------------------------------------------");
            _s.Close();
        }
        public static void WritePublicMethods(string className)
        {
            _s = new StreamWriter(@"D:\Univer\2 kurs\OOP\Lab_11\Lab_11\ClassInfo.txt", true);
            Type? currentClass = Type.GetType(className, true, true);

            IEnumerable<string?> publicMethods = new List<string?>(GetPublicMethods(currentClass!));
            _s.WriteLine($"Список публичных методов в классе {className}:");
            //foreach (var item in publicMethods)
            //{
            //    _s.WriteLine(item);
            //}
            if ((publicMethods) == null || !publicMethods.Any())
            {
                _s.WriteLine("Отсутствуют.");
            }
            else
            {
                foreach (var item in publicMethods)
                {
                    _s.WriteLine(item);
                }
            }
            _s.WriteLine("-------------------------------------------------");
            _s.Close();
        }

        public static void WriteAllFieldsAndProperties(string className)
        {
            _s = new StreamWriter(@"D:\Univer\2 kurs\OOP\Lab_11\Lab_11\ClassInfo.txt", true);
            Type? currentClass = Type.GetType(className, true, true);

            IEnumerable<MemberInfo[]> allFieldsAndProperties = new List<MemberInfo[]>(GetAllFieldsAndProperties(currentClass!));
            _s.WriteLine($"Список полей и свойств в классе {className}:");
            foreach (var dummy in allFieldsAndProperties)
            {
                foreach (var i in dummy)
                {
                    _s.WriteLine(i.ToString());
                }
            }
            _s.WriteLine("-------------------------------------------------");
            _s.Close();
        }

        public static void WriteAllInterfaces(string className)
        {
            _s = new StreamWriter(@"D:\Univer\2 kurs\OOP\Lab_11\Lab_11\ClassInfo.txt", true);
            Type? currentClass = Type.GetType(className, true, true);

            IEnumerable<string> allInterfaces = new List<string>(GetAllInterfaces(currentClass!));
            _s.WriteLine($"Список методов интерфейсов в классе {className}:");
            if ((allInterfaces) == null || !allInterfaces.Any())
            {
                _s.WriteLine("Отсутствуют.");
            }
            else
            {
                foreach (var variaInterface in allInterfaces)
                {
                    _s.WriteLine(variaInterface);
                }
            }
            _s.WriteLine("-------------------------------------------------");
            _s.Close();
        }

        public static void WriteAllClassMethodsWithParameter(string className, string userParameter)
        {
            _s = new StreamWriter(@"D:\Univer\2 kurs\OOP\Lab_11\Lab_11\ClassInfo.txt", true);
            Type? currentClass = Type.GetType(className, true, true);

            IEnumerable<string> methodsWithUserParameter = new List<string>(GetAllMethodsWithUserParameter(currentClass!, userParameter));

            _s.WriteLine($"Методы с заданным параметром {userParameter}:");
            if (methodsWithUserParameter == null || !methodsWithUserParameter.Any())
            {
                _s.WriteLine("Отсутствуют.");
            }
            else
            {
                foreach (var method in methodsWithUserParameter)
                {
                    _s.WriteLine(method);
                }
            }
            _s.WriteLine("-------------------------------------------------");
            _s.Close();
        }

        /*g. метод Invoke, который вызывает метод класса, при этом значения для его параметров необходимо 1) прочитать из текстового файла (имя класса и имя метода передаются в 
       качестве аргументов) 2) сгенерировать, используя генератор значений для каждого типа.*/
        public static void Invoke(string className, string methodName, int[]? args = null)
        {
            try
            {
                object? obj = Activator.CreateInstance(Type.GetType(className)!);
                var method = Type.GetType(className)!.GetMethod(methodName);
                List<string> list = File.ReadAllLines(@"D:\Univer\2 kurs\OOP\Lab_11\Lab_11\invoke.txt").ToList();
                object?[] list2 = { list };
                method!.Invoke(obj, list2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /* 2. Добавьте в Reflector обобщенный метод Create, который создает объект переданного типа (на основе имеющихся публичных конструкторов) и возвращает его пользователю.*/
        public static object Create(string className)
        {
            return Activator.CreateInstance(Type.GetType(className)!)!;
        }


        /*c. извлекает все общедоступные публичные методы класса (возвращает IEnumerable<string>);*/
        private static IEnumerable<string?> GetPublicMethods(Type className)
        {
            var publicMethods = new List<string?>();
            foreach (var item in className.GetMethods(BindingFlags.Public | BindingFlags.Instance))
                if (item.IsPublic)
                {
                    publicMethods.Add(item.ToString());
                }
            return publicMethods;
        }

        /*d. получает информацию о полях и свойствах класса (возвращает IEnumerable<string>);*/
        private static IEnumerable<MemberInfo[]> GetAllFieldsAndProperties(Type className)
        {
            return new List<MemberInfo[]>
            {
            className.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic),
            className.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic)
            };
        }

        /*e. получает все реализованные классом интерфейсы (возвращает IEnumerable<string>);*/
        private static IEnumerable<string> GetAllInterfaces(Type className)
        {
            var interfaces = new List<string>();
            foreach (var iInterface in className.GetInterfaces())
            {
                if (iInterface.IsPublic)
                {
                    interfaces.Add(iInterface.ToString());
                }
            }
            return interfaces;
        }

        /*f. выводит по имени класса имена методов, которые содержат заданный (пользователем) тип параметра (имя класса передается в качестве аргумента);*/
        private static IEnumerable<string> GetAllMethodsWithUserParameter(Type className, string userParameter)
        {
            var methods = new List<string>();
            var currentClassMethods = className.GetMethods();

            foreach (var item in currentClassMethods)
            {
                var parameter = item.GetParameters();
                if (parameter.Any(param => param.Name == userParameter))
                {
                    methods.Add(item.ToString()!);
                }
            }

            return methods;
        }
    }
}