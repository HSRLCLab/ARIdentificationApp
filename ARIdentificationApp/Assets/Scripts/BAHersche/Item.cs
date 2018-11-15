/* -----------------------------------------------------------------------
	Date: 14.11.2018
	Comment: Copied from Pickerzelle_V1.5_3 of BA from Simon Hersche 2017. 
	Author: Franziska Bürgler
	
---------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Item
{
    public String number { get; set; }
    public String description { get; set; }
    public String sparePartCode { get; set; }
    public String servicePart { get; set; }
    public String riskOfFailure { get; set; }
    public String price { get; set; }
    public String availability { get; set; }
    public String materialnr { get; set; }
    public int counter { get; set; }

    //public bool show { get; set; }
    public IList<Item> bom;

    public Item()
    {
        bom = new List<Item>();
    }

    public void addItem(Item item)
    {
        bom.Add(item);
    }

}