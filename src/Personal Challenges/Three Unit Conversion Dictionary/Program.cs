        private static List<string> upToTwenty;
        private static List<string> baseTenDoubleHigher;
        private static string sample;
        /// <summary>
        /// Finds the natural language equivalent of its numerical
        /// counterpart written in a string. e.g. 132 would return one hundred and thirty two
        /// </summary>
        /// <param name="sample">A string formated numeral value</param>
        /// <returns>Number to natural language version</returns>
        public static string ThreeUnitWordDictionary(string data)
        {
            sample = data;

            if (sample == "0") 
                return "Cant be 0";

            else if (sample.Length <1)
                return "Can't be an empty value";

            else if (sample.Length > 3)
                return "Can't be higher than 999";

            int unitOne = Int32.Parse(sample[0].ToString());
            string word = "";
            upToTwenty = new List<string> {
                "one","two","three","four","five","six","seven","eight",
                "nine","ten","eleven","twelve","threeteen","fourteen","fiveteen","sixteen",
                "seventeen","eighteen","nineteen"
            };        
            baseTenDoubleHigher = new List<string> {
                "twenty","thirty","fourty","fifty","sixty","seventy",
                "eighty","ninety",
            };

            if (sample.Length == 1)  //e.g. 1,2,3
                word = upToTwenty.Find(x => unitOne-1 == upToTwenty.IndexOf(x));
            
            else if (sample.Length == 2)
                word = HandleDouble(unitOne);
            
            else if (sample.Length == 3) //e.g.147
            {         
                //e.g. 1 in 1 hundred
                word = upToTwenty.Find(x => unitOne-1 == upToTwenty.IndexOf(x));
                word += " hundred";

                if (sample[1].ToString() == "0" && sample[2].ToString() == "0")
                    return word;

                else
                    word += " and ";
                sample = sample.Remove(0, 1);
                word += HandleDouble(unitOne);
            }
            return word;
        }

        /// <summary>
        /// Handle string value from 10 to 19 and from 20 to 99
        /// </summary>
        /// <param name="unitOne">Second unit of three unit number or first unit of second unit number</param>
        /// <returns></returns>
        public static string HandleDouble(int unitOne) {
            //e.g. 11,13
            int unitTwo = Int32.Parse(sample[0].ToString() + sample[1].ToString());
            string temp = upToTwenty.Find(x => unitTwo-1 == upToTwenty.IndexOf(x));
            if (temp == null)
            {
                unitOne = Int32.Parse(sample[0].ToString());
                unitTwo = Int32.Parse(sample[1].ToString());
                //e.g. 20,30
                temp = baseTenDoubleHigher.Find(x => unitOne - 2 == baseTenDoubleHigher.IndexOf(x));

                if (unitTwo == 0) //If second number is 0
                    return temp;
                //e.g. adds one unit to make 31,42
                string last = upToTwenty.Find(x => unitTwo - 1 == upToTwenty.IndexOf(x));
                temp += " " + last;
            }
            return temp;
        }
