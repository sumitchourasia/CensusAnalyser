using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.VisualBasic.FileIO;

namespace CensusAnalyser
{
    public class StateCensusAnalyser
    {
        public DataTable GetDataTabletFromCSVFile()
        {
            string path = @"C:\Users\Bridgelabz\source\repos\CensusAnalyser\CensusAnalyser\CensusAnalyser\FIles\StateCensusData.csv";

            DataTable csvData = new DataTable();

            TextFieldParser csvReader = new TextFieldParser(path);
            try
            {
                csvReader.SetDelimiters(new string[] { "," });
                    //csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datacolumn = new DataColumn(column,typeof(string));
                        //datacolumn.AllowDBNull = true;
                        csvData.Columns.Add(datacolumn);
                    }
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }
            }
            catch (Exception ex)
            {
            }
            foreach (DataRow dataRow in csvData.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.Write(item + "     ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Rows count:" + csvData.Rows.Count);
            return csvData;
        }
    }
}
