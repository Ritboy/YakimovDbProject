using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DB.Entities;

namespace DB
{
    class Storage
    {
        public static List<Organization> OrganizationsList { get; set; } = new List<Organization>();
        public static List<Supply> SuppliesList { get; set; } = new List<Supply>();
        public static List<ResponsiblePerson> ResponsiblePersonsList { get; set; } = new List<ResponsiblePerson>();

        public static void LoadData() //TODO:Сделать SQL запрос сразу для всех таблиц
        {
            SetSuppliesList(EntityManager.GetSuppliesTable());
        }

        public static void SetSuppliesList(DataTable dataTable)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (i == 0)
                {
                    continue;
                }
                SuppliesList.Add(new Supply(dataTable.Rows[i].ItemArray));
            }
        }
    }
}
