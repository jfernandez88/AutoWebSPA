using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using ExcelDataReader;
using NUnit.Framework;

namespace AutoWebSpa.Core
{
    public class ManejoDeExcel
    {

        public List<Datacollection> dataCol = new List<Datacollection>();

        public DataTable ExcelToDataTable(string fileName, string nombreHoja)
        {

            while (EsArchivoBloqueado(fileName))
            {
                Thread.Sleep(5);
            }

            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    DataTableCollection table = result.Tables;

                    DataTable resultTable = table[nombreHoja];

                    return resultTable;
                }

            }
        }


        public void PopulateInCollection(string fileName, string nombreHoja)
        {

            DataTable table = ExcelToDataTable(fileName, nombreHoja);

            while (EsArchivoBloqueado(fileName))
            {
                Thread.Sleep(200);
            }

            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };

                    dataCol.Add(dtTable);
                }
            }

        }


        public string ReadData(string caso, string columnName)
        {
            try
            {
                int rowNumber = ObtengoNroFilaDelCaso("NombreCaso", caso);

                string data = (from colData in dataCol
                               where colData.colName == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).SingleOrDefault();

                return data.ToString();
            }
            catch (Exception)
            {
                Assert.Fail("No se encontro el caso " + caso + " dentro del excel");
                return null;
            }
        }

        public Int32 ObtengoNroFilaDelCaso(string columnName, string caso)
        {
            try
            {
                int data = (from colData in dataCol
                            where colData.colName == columnName && colData.colValue == caso
                            select colData.rowNumber).SingleOrDefault();
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }

        }

        /// <summary>
        /// Metodo para validar si el excel con datos esta bloqueado por otro prosceso
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        protected virtual bool EsArchivoBloqueado(string fileName)
        {
            FileStream stream = null;

            try
            {
                stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //El archivo no esta bloqueado
            return false;
        }

        public static void LeerExcel()
        {

        }

    }


    public class Datacollection
    {
        public int rowNumber { get; set; }
        public string colName { get; set; }
        public string colValue { get; set; }
    }
}