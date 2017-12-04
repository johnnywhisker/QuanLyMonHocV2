using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRemCua
{
    class Curtain
    {
        string name,code,color,type;
        int amount;
        float price;

        public Curtain(string name,string code, string color ,string type, float price, int amount) {
            this.name = name;
            this.code = code;
            this.color = color;
            this.type = type;
            this.price = price;
            this.amount = amount;
        }
        
        public Dictionary<string,string> getData()
        {
            Dictionary<string, string> retData = new Dictionary<string, string>();
            retData["name"] = name;
            retData["code"] = code;
            retData["color"] = color;
            retData["type"] = type;
            retData["price"] = price.ToString();
            retData["amount"] = amount.ToString();
            return retData;
        }
        public bool changeData(string[] modificationInfo)
        {
            if (modificationInfo.Count() == 6)
            {
                for (int i = 0; i < 6; i++)
                {
                    switch (i)
                    {
                        case 0:
                            if (modificationInfo[i] != "")
                            {
                                this.name = modificationInfo[i];
                            }
                            break;

                        case 1:
                            if (modificationInfo[i] != "")
                            {
                                this.code = modificationInfo[i];
                            }
                            break;

                        case 2:
                            if (modificationInfo[i] != "")
                            {
                                this.color = modificationInfo[i];
                            }
                            break;

                        case 3:
                            if (modificationInfo[i] != "")
                            {
                                this.type = modificationInfo[i];
                            }
                            break;

                        case 4:
                            if (modificationInfo[i] != "")
                            {
                                this.price = float.Parse(modificationInfo[i]);
                            }
                            break;

                        case 5:
                            if (modificationInfo[i] != "")
                            {
                                this.amount = Convert.ToInt32(modificationInfo[i]);
                            }
                            break;
                    }
                }
                return true;
            }
            return false;
        }
        public bool isMe(string input) {
            input = input.ToLower();
            try
            {
                int inputAmount = Convert.ToInt32(input);
                if (amount == inputAmount)
                    return true;
                else
                    throw new InvalidCastException();
            }
            catch {
                try
                {
                    float inputPrice = float.Parse(input);
                    if (price == inputPrice)
                        return true;                    
                }
                catch
                {
                    if (name.ToLower().Contains(input) || code.ToLower().Contains(input) || color.ToLower().Contains(input) || type.ToLower().Contains(input))
                        return true;
                }
            }
            return false;
        }

    }
}
