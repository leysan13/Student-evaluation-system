using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_osenivaniya_studentov_Shamazova
{
    class Serialization
    {
        BinaryFormatter formatter = new BinaryFormatter();

        public void Serialize(List<Authorization> list)
        {
            using (FileStream fs = new FileStream("../../base.dat", FileMode.Open))
            {
                formatter.Serialize(fs, list);
            }
        }

        public List<Authorization> Deserialize()
        {
            using (FileStream fs = new FileStream("../../base.dat", FileMode.OpenOrCreate))
            {
                try
                {
                    return (List<Authorization>)formatter.Deserialize(fs);
                }
                catch
                {
                    return new List<Authorization>();
                }
            }
        }
    }
}
