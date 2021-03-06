namespace IdentificationNumberLibrary
{
    public class NumberClass
    {
        public static string GetRomaniaNumber(string surname, string gender, DateTime dateBirthday, bool residentValue, int townCode)
        {
            string identificationNumber = "";
            int year = dateBirthday.Year;
            if (year >= 1900 & year <= 1949)
            {
                identificationNumber = identificationNumber + 1;
            }
            if (year >= 1950 & year <= 1999)
            {
                identificationNumber = identificationNumber + 2;
            }
            if (year >= 1800 & year <= 1849)
            {
                identificationNumber = identificationNumber + 3;
            }
            if (year >= 1850 & year <= 1899)
            {
                identificationNumber = identificationNumber + 4;
            }
            if (year >= 2000 & year <= 2049)
            {
                identificationNumber = identificationNumber + 5;
            }
            if (year >= 2050 & year <= 2099)
            {
                identificationNumber = identificationNumber + 6;
            }
            //если человек не резидент Румынии, ставится рандомное число от 7 до 9
            if (residentValue == false)
            {
                Random rnd = new Random();
                int value = rnd.Next(7, 10);
                identificationNumber = identificationNumber + value;
            }
            return identificationNumber;
        }

        public static int GetTownCode(string townName)
        {
            int townCode;
            string path = @"../../../Roman.csv";
            string[] readText = File.ReadAllLines(path);
            foreach (string s in readText)
            {
                string[] arrayText = s.Split(',');
                if (arrayText[2] == townName)
                {
                    townCode = Convert.ToInt32(arrayText[0]);
                }
            }
            return townCode;
        }
    }
}