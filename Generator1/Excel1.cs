using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
//using Excel =  Microsoft.Office.Interop.Excel;

namespace Generator1
{
    /*
    class Excel1
    {
        public static void generateExcel(List<Aktor> kolekcjaAktors, List<Author> kolekcjaAuthors, List<Play> kolekcjaPlays)
        {
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;

            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Excel.Application();
            xlexcel.Visible = true;
            //~~> Add a new a workbook
            xlWorkBook = xlexcel.Workbooks.Open(@"C:\Users\CoX\Documents\Visual Studio 2013\Projects\Generator1\Generator1\bin\Debug\excel.xlsx");

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
                CR = (Excel.Range)xlWorkSheet.Cells[2, i];

                CR.Select();

                try
                {
                    xlWorkSheet.Paste(CR, false);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Unable to Paste clippboard to sheet. Restart program: " + ex.ToString());
                }
            }

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Item[1];
            xlWorkSheet.Select();

            for (int i = 1; i < 9 + 1; i++)
            {
                foreach (Author author in kolekcjaAuthors)
                {
                    switch (i)
                    {
                        case 1:
                            Column += author.Pesel + Environment.NewLine;
                            break;
                        case 2:
                            Column += author.Imie + " " + author.Nazwisko + Environment.NewLine;
                            break;
                        case 3:
                            Column += author.Numer + Environment.NewLine;
                            break;
                        case 4:
                            Column += author.Ulica_i_numer_domu + Environment.NewLine;
                            break;
                        case 5:
                            Column += author.Kod_pocztowy + Environment.NewLine;
                            break;
                        case 6:
                            Column += author.Miasto + Environment.NewLine;
                            break;
                        case 7:
                            Column += author.Gaza + Environment.NewLine;
                            break;
                        case 8:
                            Column += author.Rola + Environment.NewLine;
                            break;
                        case 9:
                            Column += author.Wiek + Environment.NewLine;
                            break;
                    }
                }
                Clipboard.SetText(Column);
                Column = "";
                //~~> Set your range
                CR = (Excel.Range)xlWorkSheet.Cells[2, i];

                CR.Select();
                try
                {
                    xlWorkSheet.Paste(CR, false);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Unable to Paste clippboard to sheet " + ex.ToString());
                }
                
            }

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Item[3];
            xlWorkSheet.Select();

            for (int i = 1; i < 5 + 1; i++)
            {
                foreach (Play play in kolekcjaPlays)
                {
                    switch (i)
                    {
                        case 1:
                            Column += play.Tytul + Environment.NewLine;
                            break;
                        case 2:
                            Column += play.Autor+ Environment.NewLine;
                            break;
                        case 3:
                            Column += play.Gatunek + Environment.NewLine;
                            break;
                        case 4:
                            foreach (Aktor aktor in play.ListaAktorow)
                            {
                                Column += aktor.Imie + " " + aktor.Nazwisko + ", ";
                            }
                            Column += Environment.NewLine;
                            break;
                        case 5:
                            Column += play.Rezyser + Environment.NewLine;
                            break;
                    }
                }
                Clipboard.SetText(Column);
                Column = "";
                //~~> Set your range
                CR = (Excel.Range)xlWorkSheet.Cells[2, i];

                CR.Select();
                try
                {
                    xlWorkSheet.Paste(CR, false);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Unable to Paste clippboard to sheet " + ex.ToString());
                }

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
     * */
}
