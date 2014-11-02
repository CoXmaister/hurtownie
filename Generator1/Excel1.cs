using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Excel =  Microsoft.Office.Interop.Excel;

namespace Generator1
{
    class Excel1
    {
        public static void generateExcel(List<Aktor> kolekcjaAktors)
        {
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;

            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Excel.Application();
            xlexcel.Visible = true;

            //~~> Add a new a workbook
            xlWorkBook = xlexcel.Workbooks.Add(misValue);

            //~~> Set Sheet 1 as the sheet you want to work with
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Item[2];
            xlWorkSheet.Select();
            String Column="";

            Excel.Range CR;
            for (int i = 1; i < 8 + 1; i++)
            {
                foreach (Aktor Aktor in kolekcjaAktors)
                {
                    switch (i)
                    {
                        case 1:
                            Column += Aktor.Pesel + Environment.NewLine;
                            break;
                        case 2:
                            Column += Aktor.Imie + " " + Aktor.Nazwisko + Environment.NewLine;
                            break;
                        case 3:
                            Column += Aktor.Numer + Environment.NewLine;
                            break;
                        case 4:
                            Column += Aktor.Ulica_i_numer_domu + Environment.NewLine;
                            break;
                        case 5:
                            Column += Aktor.Kod_pocztowy + Environment.NewLine;
                            break;
                        case 6:
                            Column += Aktor.Miasto + Environment.NewLine;
                            break;
                        case 7:
                            Column += Aktor.Gaza + Environment.NewLine;
                            break;
                        case 8:
                            Column += Aktor.Wiek + Environment.NewLine;
                            break;
                    }
                }
                Clipboard.SetText(Column);
                Column = "";
                //~~> Set your range
                CR = (Excel.Range)xlWorkSheet.Cells[1, i];

                CR.Select();

                xlWorkSheet.Paste(CR, false);
            }

            

            xlWorkBook.Close(true, misValue, misValue);
            xlexcel.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlexcel);
        }

        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        } 

    }
}
