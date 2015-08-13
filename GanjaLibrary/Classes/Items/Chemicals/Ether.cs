/*
    
    Ethers /ˈiːθər/ are a class of organic compounds that contain an ether group — an oxygen 
    atom connected to two alkyl or aryl groups — of general formula R–O–R'. These ethers 
    can again be classified into two varieties , if the alkyl groups are the same on both 
    sides of the oxygen atom then it is a simple or symmetrical ether. Whereas if they are 
    different the ethers are called mixed or unsymmetrical ethers.[1] A typical example is the 
    solvent and anesthetic diethyl ether, commonly referred to simply as "ether" 
    (CH3-CH2-O-CH2-CH3). Ethers are common in organic chemistry and pervasive in biochemistry, 
    as they are common linkages in carbohydrates and lignin.

    - https://en.wikipedia.org/wiki/Ether

    Ether is used as a chemical to create Honey Oil with.
    This oil is itself is good, giving an 100% boost to yield. 

*/


using GanjaLibrary.Interfaces.Items;

namespace GanjaLibrary.Classes.Items
{
    public class Ether : Item, IItem
    {
        public Ether() : base("Ether", "99.9% pure alcohol solution. CAUTION: Volatile substance. Contents 1000 ml.", 1, 75)
        {
        }
    }
}