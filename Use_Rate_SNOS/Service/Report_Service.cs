using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Use_Rate_SNOS.Service
{
    //class Report_Service

    //{
    //    Microsoft.Office.Interop.Excel.Application excel;
    //    Microsoft.Office.Interop.Excel.Workbook excelworkBook;
    //    Microsoft.Office.Interop.Excel.Worksheet excelSheet;
    //    //Microsoft.Office.Interop.Excel.Range excelCellrange;
    //    int Headerrow = 4;
    //    string reportname = "";
    //    public Report_Service(Enum.Report_Type type)
    //    {
    //        // Start Excel and get Application object.  
    //        excel = new Microsoft.Office.Interop.Excel.Application();
    //        // for making Excel visible  
    //        excel.Visible = false;
    //        excel.DisplayAlerts = false;
    //        // Creation a new Workbook  
    //        excelworkBook = excel.Workbooks.Add(Type.Missing);
    //        // Workk sheet  
    //        excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
    //        // Format column A as text.
    //        excelSheet.Range["A:Z"].NumberFormat = "@";
    //        excelSheet.Range["A:Z"].Font.Size = 14;
    //        switch (type)
    //        {
    //            case Enum.Report_Type.Report_Approve:
    //                reportname = "Report_Approve";
    //                excelSheet.Name = reportname + DateTime.Now.ToString("yyMMdd");
    //                break;
    //            case Enum.Report_Type.Report_Import:
    //                reportname = "Report_Import";
    //                excelSheet.Name = reportname + DateTime.Now.ToString("yyMMdd");
    //                break;
    //            case Enum.Report_Type.Report_Part_Left:
    //                reportname = "Report_Part_Left";
    //                excelSheet.Name = reportname + DateTime.Now.ToString("yyMMdd");
    //                break;
    //            case Enum.Report_Type.Report_Part_Management:
    //                reportname = "Report_Part_Management";
    //                excelSheet.Name = reportname + DateTime.Now.ToString("yyMMdd");
    //                break;
    //            case Enum.Report_Type.Report_Pickup:
    //                reportname = "Report_Pickup";
    //                excelSheet.Name = reportname + DateTime.Now.ToString("yyMMdd");
    //                break;
    //            case Enum.Report_Type.Report_Stock:
    //                reportname = "Report_Stock";
    //                excelSheet.Name = reportname + DateTime.Now.ToString("yyMMdd");
    //                break;
    //            case Enum.Report_Type.Report_Supplier_Management:
    //                reportname = "Report_Supplier_Management";
    //                excelSheet.Name = reportname + DateTime.Now.ToString("yyMMdd");
    //                break;
    //        }
    //    }
    //    private void setcolor(int range)
    //    {
    //        for (int i = 1; i <= range; i++)
    //        {
    //            excelSheet.Cells[Headerrow, i].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(0, 255, 255));
    //            excelSheet.Cells[Headerrow, i].EntireRow.Font.Bold = true;
    //        }

    //    }
    //    private void setboder(int range, int row)
    //    {
    //        for (int i = 1; i <= range; i++)
    //        {
    //            excelSheet.Cells[row, i].Borders.Weight = XlBorderWeight.xlThin;
    //        }

    //    }
    //    private string datecheck(DateTime data)
    //    {
    //        string date = "";
    //        if (data.Year < 2000)
    //        {

    //        }
    //        else
    //        {
    //            date = data.ToString("dd/MM/yyyy HH:mm");
    //        }
    //        return date;
    //    }
    //    public void write(List<Report_Approve_Entity> data, string path)
    //    {
    //        //Header Row 1
    //        excelSheet.Cells[1, 1] = "Sonoda (Thailand) Co.,LTD.";
    //        excelSheet.Cells[1, 6] = DateTime.Now.ToString("yyyy/MM/dd");
    //        //Header Row 2
    //        excelSheet.Cells[2, 1] = reportname;
    //        //Header Row 3
    //        excelSheet.Cells[Headerrow, 1] = "Apporve Type Name";
    //        excelSheet.Cells[Headerrow, 2] = "Date";
    //        excelSheet.Cells[Headerrow, 3] = "Apporve date";
    //        excelSheet.Cells[Headerrow, 4] = "Request Name";
    //        excelSheet.Cells[Headerrow, 5] = "Apporve By Name";
    //        excelSheet.Cells[Headerrow, 6] = "Apporve Text";
    //        int row = 5;
    //        setboder(6, Headerrow);
    //        //Data
    //        foreach (Report_Approve_Entity item in data)
    //        {
    //            excelSheet.Cells[row, 1] = item.Apporve_Type_Name;
    //            excelSheet.Cells[row, 2] = datecheck(item.Date);
    //            excelSheet.Cells[row, 3] = datecheck(item.Apporve_date);
    //            excelSheet.Cells[row, 4] = item.Request_Name;
    //            excelSheet.Cells[row, 5] = item.Apporve_By_Name;
    //            excelSheet.Cells[row, 6] = item.Apporve_Text;
    //            setboder(6, row);
    //            row++;
    //        }
    //        setcolor(6);
    //        save(path);
    //    }
    //    public void write(List<Report_PickUp_Entity> data, string path)
    //    {
    //        //Header Row 1
    //        excelSheet.Cells[1, 1] = "Sonoda (Thailand) Co.,LTD.";
    //        excelSheet.Cells[1, 12] = DateTime.Now.ToString("yyyy/MM/dd");
    //        //Header Row 2
    //        excelSheet.Cells[2, 1] = reportname;
    //        //Header Row 3
    //        excelSheet.Cells[Headerrow, 1] = "Doc No.";
    //        excelSheet.Cells[Headerrow, 2] = "Date";
    //        excelSheet.Cells[Headerrow, 3] = "Job";
    //        excelSheet.Cells[Headerrow, 4] = "Machine Code";
    //        excelSheet.Cells[Headerrow, 5] = "Requester ID";
    //        excelSheet.Cells[Headerrow, 6] = "Requester Name";
    //        excelSheet.Cells[Headerrow, 7] = "Barcode ID";
    //        excelSheet.Cells[Headerrow, 8] = "Name EN";
    //        excelSheet.Cells[Headerrow, 9] = "Name TH";
    //        excelSheet.Cells[Headerrow, 10] = "Total";
    //        excelSheet.Cells[Headerrow, 11] = "Description";
    //        excelSheet.Cells[Headerrow, 12] = "Remark";
    //        int row = 5;
    //        setboder(12, Headerrow);
    //        //Data
    //        foreach (Report_PickUp_Entity item in data)
    //        {
    //            excelSheet.Cells[row, 1] = "SNDI-" + item.Date.ToString("yyMM") + "-" + item.Doc_No.ToString("000");
    //            excelSheet.Cells[row, 2] = datecheck(item.Date);
    //            excelSheet.Cells[row, 3] = item.Job;
    //            excelSheet.Cells[row, 4] = item.Machine_Code;
    //            excelSheet.Cells[row, 5] = item.User_ID;
    //            excelSheet.Cells[row, 6] = item.Reveal_Name;
    //            excelSheet.Cells[row, 7] = item.Barcode_ID;
    //            excelSheet.Cells[row, 8] = item.Name_EN;
    //            excelSheet.Cells[row, 9] = item.Name_TH;
    //            excelSheet.Cells[row, 10] = item.Item_QUANTITY;
    //            excelSheet.Cells[row, 11] = item.Description;
    //            excelSheet.Cells[row, 12] = item.Remark;
    //            setboder(12, row);
    //            row++;
    //        }
    //        setcolor(12);
    //        save(path);
    //    }
    //    public void write(List<SND_Part> data, string path, Enum.Report_Type type)
    //    {
    //        if (type == Enum.Report_Type.Report_Stock)
    //        {
    //            //Header Row 1
    //            excelSheet.Cells[1, 1] = "Sonoda (Thailand) Co.,LTD.";
    //            excelSheet.Cells[1, 9] = DateTime.Now.ToString("yyyy/MM/dd");
    //            //Header Row 2
    //            excelSheet.Cells[2, 1] = reportname;
    //            //Header Row 3
    //            excelSheet.Cells[Headerrow, 1] = "ID_PRODUCT";
    //            excelSheet.Cells[Headerrow, 2] = "NAME PRODUCT ENG";
    //            excelSheet.Cells[Headerrow, 3] = "NAME PRODUCT TH";
    //            excelSheet.Cells[Headerrow, 4] = "MAKER";
    //            excelSheet.Cells[Headerrow, 5] = "QUANTITY";
    //            excelSheet.Cells[Headerrow, 6] = "UNIT";
    //            excelSheet.Cells[Headerrow, 7] = "UNIT PRICE";
    //            excelSheet.Cells[Headerrow, 8] = "Description";
    //            excelSheet.Cells[Headerrow, 9] = "Location";
    //            int row = 5;
    //            setboder(9, Headerrow);
    //            //Data
    //            foreach (SND_Part item in data)
    //            {
    //                excelSheet.Cells[row, 1] = item.ID_PRODUCT;
    //                excelSheet.Cells[row, 2] = item.NAME_PRODUCT_ENG;
    //                excelSheet.Cells[row, 3] = item.NAME_PRODUCT_TH;
    //                excelSheet.Cells[row, 4] = item.MAKER;
    //                excelSheet.Cells[row, 5] = item.QUANTITY;
    //                excelSheet.Cells[row, 6] = item.UNIT;
    //                excelSheet.Cells[row, 7] = item.UNIT_PRICE;
    //                excelSheet.Cells[row, 8] = item.Description;
    //                excelSheet.Cells[row, 9] = item.Location;
    //                setboder(9, row);
    //                row++;
    //            }
    //            setcolor(9);
    //        }
    //        else if (type == Enum.Report_Type.Report_Part_Left)
    //        {
    //            //Header Row 1
    //            excelSheet.Cells[1, 1] = "Sonoda (Thailand) Co.,LTD.";
    //            excelSheet.Cells[1, 5] = DateTime.Now.ToString("yyyy/MM/dd");
    //            //Header Row 2
    //            excelSheet.Cells[2, 1] = reportname;
    //            //Header Row 3
    //            excelSheet.Cells[Headerrow, 1] = "ID_PRODUCT";
    //            excelSheet.Cells[Headerrow, 2] = "NAME PRODUCT ENG";
    //            excelSheet.Cells[Headerrow, 3] = "NAME PRODUCT TH";
    //            excelSheet.Cells[Headerrow, 4] = "QUANTITY";
    //            excelSheet.Cells[Headerrow, 5] = "UNIT";
    //            int row = 5;
    //            setboder(5, Headerrow);
    //            //Data
    //            foreach (SND_Part item in data)
    //            {
    //                excelSheet.Cells[row, 1] = item.ID_PRODUCT;
    //                excelSheet.Cells[row, 2] = item.NAME_PRODUCT_ENG;
    //                excelSheet.Cells[row, 3] = item.NAME_PRODUCT_TH;
    //                excelSheet.Cells[row, 4] = item.QUANTITY;
    //                excelSheet.Cells[row, 5] = item.UNIT;
    //                setboder(5, row);
    //                row++;
    //            }
    //            setcolor(5);
    //        }
    //        save(path);
    //    }
    //    public void write(List<Report_Import_Entity> data, string path, double rate)
    //    {
    //        //Header Row 1
    //        excelSheet.Cells[1, 1] = "Sonoda (Thailand) Co.,LTD.";
    //        excelSheet.Cells[1, 18] = DateTime.Now.ToString("yyyy/MM/dd");
    //        //Header Row 2
    //        excelSheet.Cells[2, 1] = reportname;
    //        //Header Row 3
    //        excelSheet.Cells[Headerrow, 1] = "Doc No.";
    //        excelSheet.Cells[Headerrow, 2] = "DATE";
    //        excelSheet.Cells[Headerrow, 3] = "PO NO";
    //        excelSheet.Cells[Headerrow, 4] = "Import Date";
    //        excelSheet.Cells[Headerrow, 5] = "Delivery Order Number";
    //        excelSheet.Cells[Headerrow, 6] = "Supprier ID";
    //        excelSheet.Cells[Headerrow, 7] = "Supprier Name";
    //        excelSheet.Cells[Headerrow, 8] = "Supprier Detail";
    //        excelSheet.Cells[Headerrow, 9] = "Phone Number";
    //        excelSheet.Cells[Headerrow, 10] = "Barcode ID";
    //        excelSheet.Cells[Headerrow, 11] = "Name EN";
    //        excelSheet.Cells[Headerrow, 12] = "Name TH";
    //        excelSheet.Cells[Headerrow, 13] = "QUANTITY";
    //        excelSheet.Cells[Headerrow, 14] = "PRICE";
    //        //excelSheet.Cells[Headerrow, 14] = "Total Quantity";
    //        excelSheet.Cells[Headerrow, 15] = "TOTAL PRICE";
    //        excelSheet.Cells[Headerrow, 16] = "RECEIVER";
    //        excelSheet.Cells[Headerrow, 17] = "DESCRIPTION";
    //        excelSheet.Cells[Headerrow, 18] = "REMARK";
    //        int row = 5;
    //        setboder(18, Headerrow);
    //        //Data
    //        foreach (Report_Import_Entity item in data)
    //        {
    //            excelSheet.Cells[row, 1] = "SNDI-" + item.DATE.ToString("yyMM") + "-" + item.Doc_No.ToString("000");
    //            excelSheet.Cells[row, 2] = datecheck(item.DATE);
    //            excelSheet.Cells[row, 3] = item.PO_NO;
    //            excelSheet.Cells[row, 4] = item.Import_Date;
    //            excelSheet.Cells[row, 5] = item.Delivery_Order_Number;
    //            excelSheet.Cells[row, 6] = item.Supprier_ID;
    //            excelSheet.Cells[row, 7] = item.Supprier_Name;
    //            excelSheet.Cells[row, 8] = item.Supprier_detail;
    //            excelSheet.Cells[row, 9] = item.Phone_Number;
    //            excelSheet.Cells[row, 10] = item.Barcode_ID;
    //            excelSheet.Cells[row, 11] = item.Name_EN;
    //            excelSheet.Cells[row, 12] = item.Name_TH;
    //            excelSheet.Cells[row, 13] = item.QUANTITY;
    //            excelSheet.Cells[row, 14] = ((Convert.ToDouble(item.PRICE)) / rate).ToString("0.######");
    //            //excelSheet.Cells[row, 14] = item.Total_Quantity;
    //            excelSheet.Cells[row, 15] = ((Convert.ToDouble((item.QUANTITY * item.PRICE))) / rate).ToString("0.######");
    //            excelSheet.Cells[row, 16] = item.RECEIVER;
    //            excelSheet.Cells[row, 17] = item.DESCRIPTION;
    //            excelSheet.Cells[row, 18] = item.REMARK;
    //            setboder(18, row);
    //            row++;
    //        }
    //        setcolor(18);
    //        save(path);
    //    }
    //    public void write(List<Report_Part_ManagementEntity> data, string path)
    //    {
    //        //Header Row 1
    //        excelSheet.Cells[1, 1] = "Sonoda (Thailand) Co.,LTD.";
    //        excelSheet.Cells[1, 13] = DateTime.Now.ToString("yyyy/MM/dd");
    //        //Header Row 2
    //        excelSheet.Cells[2, 1] = reportname;
    //        //Header Row 3
    //        excelSheet.Cells[Headerrow, 1] = "Type";
    //        excelSheet.Cells[Headerrow, 2] = "Date Request";
    //        excelSheet.Cells[Headerrow, 3] = "Apporved date";
    //        excelSheet.Cells[Headerrow, 4] = "ID_PRODUCT";
    //        excelSheet.Cells[Headerrow, 5] = "Barcode ID";
    //        excelSheet.Cells[Headerrow, 6] = "NAME PRODUCT ENG";
    //        excelSheet.Cells[Headerrow, 7] = "NAME PRODUCT TH";
    //        excelSheet.Cells[Headerrow, 8] = "MAKER";
    //        excelSheet.Cells[Headerrow, 9] = "QUANTITY";
    //        excelSheet.Cells[Headerrow, 10] = "UNIT";
    //        excelSheet.Cells[Headerrow, 11] = "UNIT PRICE";
    //        excelSheet.Cells[Headerrow, 12] = "Description";
    //        excelSheet.Cells[Headerrow, 13] = "Location";
    //        int row = 5;
    //        setboder(13, Headerrow);
    //        //Data
    //        foreach (Report_Part_ManagementEntity item in data)
    //        {
    //            excelSheet.Cells[row, 1] = item.Apporve_Type_Name;
    //            excelSheet.Cells[row, 2] = datecheck(item.Date);
    //            excelSheet.Cells[row, 3] = datecheck(item.Apporve_date);
    //            excelSheet.Cells[row, 4] = item.ID_PRODUCT;
    //            excelSheet.Cells[row, 5] = item.Barcode_ID;
    //            excelSheet.Cells[row, 6] = item.NAME_PRODUCT_ENG;
    //            excelSheet.Cells[row, 7] = item.NAME_PRODUCT_TH;
    //            excelSheet.Cells[row, 8] = item.MAKER;
    //            excelSheet.Cells[row, 9] = item.QUANTITY;
    //            excelSheet.Cells[row, 10] = item.UNIT;
    //            excelSheet.Cells[row, 11] = item.UNIT_PRICE;
    //            excelSheet.Cells[row, 12] = item.Description;
    //            excelSheet.Cells[row, 13] = item.Location;
    //            setboder(13, row);
    //            row++;
    //        }
    //        setcolor(13);
    //        save(path);
    //    }
    //    public void write(List<Report_Suppiler_ManagementEntity> data, string path)
    //    {
    //        //Header Row 1
    //        excelSheet.Cells[1, 1] = "Sonoda (Thailand) Co.,LTD.";
    //        excelSheet.Cells[1, 25] = DateTime.Now.ToString("yyyy/MM/dd");
    //        //Header Row 2
    //        excelSheet.Cells[2, 1] = reportname;
    //        //Header Row 3
    //        excelSheet.Cells[Headerrow, 1] = "Type";
    //        excelSheet.Cells[Headerrow, 2] = "Date Request";
    //        excelSheet.Cells[Headerrow, 3] = "Apporved date";
    //        excelSheet.Cells[Headerrow, 4] = "SupplierID";
    //        excelSheet.Cells[Headerrow, 5] = "SupplierName";
    //        excelSheet.Cells[Headerrow, 6] = "AddressDetail";
    //        excelSheet.Cells[Headerrow, 7] = "Country";
    //        excelSheet.Cells[Headerrow, 8] = "Province";
    //        excelSheet.Cells[Headerrow, 9] = "District";
    //        excelSheet.Cells[Headerrow, 10] = "Sub_District";
    //        excelSheet.Cells[Headerrow, 11] = "PostCode";
    //        excelSheet.Cells[Headerrow, 12] = "Email";
    //        excelSheet.Cells[Headerrow, 13] = "Email2";
    //        excelSheet.Cells[Headerrow, 14] = "FirstName1";
    //        excelSheet.Cells[Headerrow, 15] = "LastName1";
    //        excelSheet.Cells[Headerrow, 16] = "MobileNumber1";
    //        excelSheet.Cells[Headerrow, 17] = "FirstName2";
    //        excelSheet.Cells[Headerrow, 18] = "LastName2";
    //        excelSheet.Cells[Headerrow, 19] = "MobileNumber2";
    //        excelSheet.Cells[Headerrow, 20] = "PhoneNumber1";
    //        excelSheet.Cells[Headerrow, 21] = "PhoneNumber2";
    //        excelSheet.Cells[Headerrow, 22] = "Fax1";
    //        excelSheet.Cells[Headerrow, 23] = "Fax2";
    //        excelSheet.Cells[Headerrow, 24] = "Credit";
    //        excelSheet.Cells[Headerrow, 25] = "Account_No";
    //        int row = 5;
    //        setboder(25, Headerrow);
    //        //Data
    //        foreach (Report_Suppiler_ManagementEntity item in data)
    //        {
    //            excelSheet.Cells[row, 1] = item.Apporve_Type_Name;
    //            excelSheet.Cells[row, 2] = datecheck(item.Date);
    //            excelSheet.Cells[row, 3] = datecheck(item.Apporve_date);
    //            excelSheet.Cells[row, 4] = item.SupplierID;
    //            excelSheet.Cells[row, 5] = item.SupplierName;
    //            excelSheet.Cells[row, 6] = item.AddressDetail;
    //            excelSheet.Cells[row, 7] = item.Country;
    //            excelSheet.Cells[row, 8] = item.Province;
    //            excelSheet.Cells[row, 9] = item.District;
    //            excelSheet.Cells[row, 10] = item.Sub_District;
    //            excelSheet.Cells[row, 11] = item.PostCode;
    //            excelSheet.Cells[row, 12] = item.Email;
    //            excelSheet.Cells[row, 13] = item.Email2;
    //            excelSheet.Cells[row, 14] = item.FirstName1;
    //            excelSheet.Cells[row, 15] = item.LastName1;
    //            excelSheet.Cells[row, 16] = item.MobileNumber1;
    //            excelSheet.Cells[row, 17] = item.FirstName2;
    //            excelSheet.Cells[row, 18] = item.LastName2;
    //            excelSheet.Cells[row, 19] = item.MobileNumber2;
    //            excelSheet.Cells[row, 20] = item.PhoneNumber1;
    //            excelSheet.Cells[row, 21] = item.PhoneNumber2;
    //            excelSheet.Cells[row, 22] = item.Fax1;
    //            excelSheet.Cells[row, 23] = item.Fax2;
    //            excelSheet.Cells[row, 24] = item.Credit;
    //            excelSheet.Cells[row, 25] = item.Account_No;
    //            setboder(25, row);
    //            row++;
    //        }
    //        setcolor(25);
    //        save(path);
    //    }
    //    private void save(string path)
    //    {
    //        //Save the file in the given path
    //        try
    //        {
    //            excelSheet.Columns.AutoFit();
    //            excelworkBook.SaveAs(@"" + path);
    //            excelworkBook.Close();
    //            Message message = new Message("Export success");
    //            message.Show();
    //        }
    //        catch
    //        {
    //            Message message = new Message("Export fail");
    //            message.Show();
    //        }

    //    }

    //}
}
