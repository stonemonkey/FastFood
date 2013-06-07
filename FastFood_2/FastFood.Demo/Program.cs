using System;
using FastFood.Ordering;

namespace FastFood.Demo
{
    class Program
    {
        // Problema: Servirea unui meniu intr-un fast-food.

        // Un meniu cuprinde un burger, o bautura rece, cartofi si o jucarie. La fiecare comanda, chelnerul va 
        // lua un burger, cartofii, bautura si jucaria si le va impacheta. Exista 3 tipuri de burger disponibili: 
        // Vegetable, Fish si Chicken; 2 tipuri de bauturi: Cola si Orange si 2 tipuri de jucarii: Car si Doll. 
        // Iar fiecare element din meniu are un pret.

        // Comanda poate fi o combinatie a acestora insa procesul este acelasi (burger, drink, fries, toy). Acestea 
        // sunt puse intr-o punga si date clientului. Inainte de a fi puse in punga, fiecare element in afara de 
        // jucarie este impachetat separat.

        static void Main()
        {
            Console.WriteLine("Fo FastFood meal service (c) September 2012\n");
            Console.WriteLine("!!! Burger + Drink + Fries + Toy !!!\n");

            var priceList = new FoPriceList();
            var cateringOperations = new FoCateringOperations(priceList);
            
            var burgerType = GetEnumMenuSelection<BurgerTypes>(
                priceList.GetBurgerPrice, "Choose your burger (q/Q - quit): ");
            var drinkType = GetEnumMenuSelection<DrinkTypes>(
                priceList.GetDrinkPrice, "Choose your drink (q/Q - quit): ");
            var toyType = GetEnumMenuSelection<ToyTypes>(
                priceList.GetToyPrice, "Choose your toy (q/Q - quit): ");
            
            var waiter = new FoWaiter(cateringOperations);

            var order = new Order(burgerType, drinkType, toyType);
            var mealBag = waiter.CreateMeal(order);
            
            Console.WriteLine("Your meal is searved and contains: ");
            
            mealBag.PrintContent();
            
            Console.WriteLine("Total price: {0} ron", mealBag.Price);
            
            Console.ReadLine();
        }

        #region Some Menu Helpers

        static TEnum GetEnumMenuSelection<TEnum>(Func<TEnum, decimal> getPrice, string question) 
            where TEnum : struct
        {
            ShowMenu(getPrice);

            return ParseResponse<TEnum>(question);
        }

        private static TEnum ParseResponse<TEnum>(string question) 
            where TEnum : struct
        {
            TEnum result;
            string response;

            do 
                response = AskUser(question);
            while (!TryGetValidResult(response, out result));

            Console.WriteLine();
            
            return result;
        }

        private static bool TryGetValidResult<TEnum>(string response, out TEnum result) 
            where TEnum : struct
        {
            return Enum.TryParse(response, out result) && 
                  (Enum.GetName(typeof (TEnum), result) != null);
        }

        private static string AskUser(string question)
        {
            Console.Write(question);
            var response = Console.ReadLine();

            if ((response != null) && response.ToLower().Equals("q"))
                Environment.Exit(1);
            
            return response;
        }

        private static void ShowMenu<TEnum>(Func<TEnum, decimal> getPrice) 
            where TEnum : struct
        {
            var itemValues = Enum.GetValues(typeof (TEnum));

            foreach (var itemValue in itemValues)
                Console.WriteLine("[{0}] {1} - {2} ron", (int) itemValue, itemValue, getPrice((TEnum) itemValue));
        }
        
        #endregion
    }
}
