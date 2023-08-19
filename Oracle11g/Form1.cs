using Oracle.ManagedDataAccess.Client;
using Oracle11g.Connection;
using Oracle11g.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oracle11g
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            setCombobox();
            setButtonVisible();
        }

        BONUS bonus       = null;
        DEPT dept         = null;
        EMP emp           = null;
        SALGRADE salgrade = null;

        private void btnSelect_Click(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = null;
            dataGridView1.Refresh();
            OracleDataReader rdr = null;
            string sql = string.Empty;
            try
            {
                switch (cbTable.Text)
                {
                    case "BONUS":
                        BONUSdataService bonusService = new BONUSdataService();
                        sql = bonusService.GetSelectSQL(new BONUS(), "");
                        rdr = bonusService.selectQuery(sql);

                        List<BONUS> listbonus = bonusService._Read(rdr);
                        Global.G_list_bonus = listbonus;
                        dataGridView1.DataSource = listbonus;
                        propertyGrid1.SelectedObject = listbonus[0];
                        listbonus = null;
                        break;

                    case "DEPT":
                        DEPTdataService deptService = new DEPTdataService();
                        sql = deptService.GetSelectSQL(new DEPT(), "");
                        rdr = deptService.selectQuery(sql);

                        List<DEPT> listdept = deptService._Read(rdr);
                        Global.G_list_dept = listdept;
                        dataGridView1.DataSource = listdept;
                        propertyGrid1.SelectedObject = listdept[0];
                        listdept = null;
                        break;

                    case "EMP":
                        EMPdataService empService = new EMPdataService();
                        sql = empService.GetSelectSQL(new EMP(), "");
                        rdr = empService.selectQuery(sql);

                        List<EMP> listemp = empService._Read(rdr);
                        Global.G_list_emp = listemp;
                        dataGridView1.DataSource = listemp;
                        propertyGrid1.SelectedObject = listemp[0];
                        listemp = null;
                        break;

                    case "SALGRADE":
                        SALGRADEdataService salgradeService = new SALGRADEdataService();
                        sql = salgradeService.GetSelectSQL(new SALGRADE(), "");
                        rdr = salgradeService.selectQuery(sql);

                        List<SALGRADE> listsalgrade = salgradeService._Read(rdr);
                        Global.G_list_salgrade = listsalgrade;
                        dataGridView1.DataSource = listsalgrade;
                        propertyGrid1.SelectedObject = listsalgrade[0];
                        listsalgrade = null;
                        break;
                    case "":
                        MessageBox.Show("Table 을 선택하세요", "Error");
                        break;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                setButtonVisible();
                rdr = null;
                sql = string.Empty;
            }

        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            bool result = false;
            DBConnection dbconn = new DBConnection();
            try
            {
                switch (cbTable.Text)
                {
                    case "BONUS":
                        BONUSdataService bonusService = new BONUSdataService();
                        sql = bonusService.GetCreateSQL(Global.G_bonus_update);
                        result = dbconn.Query(sql);
                        break;
                    case "DEPT":
                        DEPTdataService deptService = new DEPTdataService();
                        sql = deptService.GetCreateSQL(Global.G_dept_update);
                        result = dbconn.Query(sql);
                        break;
                    case "EMP":
                        EMPdataService empService = new EMPdataService();
                        sql = empService.GetCreateSQL(Global.G_emp_update);
                        result = dbconn.Query(sql);
                        break;
                    case "SALGRADE":
                        SALGRADEdataService salgradeService = new SALGRADEdataService();
                        sql = salgradeService.GetCreateSQL(Global.G_salgrade_update);
                        result = dbconn.Query(sql);
                        break;
                    case "":
                        MessageBox.Show("Table 을 선택하세요", "Error");
                        break;
                }
            }
            catch
            {

            }
            finally
            {
                if (!result)
                {
                    MessageBox.Show("실패", "Error");
                }
                else
                {
                    MessageBox.Show("성공", "Success");
                }
                Global.G_bonus_update = null;
                Global.G_dept_update = null;
                Global.G_emp_update = null;
                Global.G_salgrade_update = null;
                setButtonVisible();
                //-- Log 관리
                new QueryLog().Logging(cbTable.Text, sql, result.ToString(), QueryLog.LOGTYPE.TEXT);
                sql = string.Empty;
                btnSelect.PerformClick();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            string whereCondition = string.Empty;
            bool result = false;
            DBConnection dbconn = new DBConnection();
            try
            {
                switch (cbTable.Text)
                {
                    case "BONUS":
                        BONUSdataService bonusService = new BONUSdataService();
                        whereCondition = "ENAME = '" + Global.G_bonus_update.ENAME + "'";
                        sql = bonusService.GetDeleteSQL(new BONUS(), whereCondition);
                        result = dbconn.Query(sql);
                        break;

                    case "DEPT":
                        DEPTdataService deptService = new DEPTdataService();
                        whereCondition = "DPTNO = '" + Global.G_dept_update.DEPTNO + "'";
                        sql = deptService.GetDeleteSQL(new DEPT(), whereCondition);
                        result = dbconn.Query(sql);
                        break;

                    case "EMP":
                        EMPdataService empService = new EMPdataService();
                        whereCondition = "EMPNO = '" + Global.G_emp_update.EMPNO + "'";
                        sql = empService.GetDeleteSQL(new EMP(), whereCondition);
                        result = dbconn.Query(sql);
                        break;

                    case "SALGRADE":
                        SALGRADEdataService salgradeService = new SALGRADEdataService();
                        whereCondition = "GRADE = '" + Global.G_salgrade_update.GRADE + "'";
                        sql = salgradeService.GetDeleteSQL(new SALGRADE(), whereCondition);
                        result = dbconn.Query(sql);
                        break;

                    case "":
                        MessageBox.Show("Table 을 선택하세요", "Error");
                        break;
                }
            }
            catch
            {

            }
            finally
            {
                if (!result)
                {
                    MessageBox.Show("실패", "Error");
                }
                else
                {
                    MessageBox.Show("성공", "Success");
                }
                Global.G_bonus_update = null;
                Global.G_dept_update = null;
                Global.G_emp_update = null;
                Global.G_salgrade_update = null;
                setButtonVisible();

                new QueryLog().Logging(cbTable.Text, sql, result.ToString(), QueryLog.LOGTYPE.TEXT);
                sql = string.Empty;
                btnSelect.PerformClick();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            string whereCondition = string.Empty;
            string compareStr = string.Empty;
            string reasonFail = string.Empty;
            bool result = false;
            DBConnection dbconn = new DBConnection();
            OracleDataReader rdr = null;
            try
            {
                switch (cbTable.Text)
                {
                    case "BONUS":
                        // 기존 BONUS VALUE
                        compareStr = bonus.ENAME;
                        BONUSdataService bonusService = new BONUSdataService();
                        whereCondition = "ENAME = '" + Global.G_bonus_update.ENAME + "'";
                        sql = bonusService.GetUpdateSQL(Global.G_bonus_update, whereCondition);

                        // 기존 EMPNO와 비교 다르면 에러
                        if (!compareStr.Equals(Global.G_emp_update.ENAME))
                        {
                            result = false;
                            reasonFail = "ENAME 를 변경할수 없습니다.";
                            break;
                        }

                        result = dbconn.Query(sql);
                        break;

                    case "DEPT":
                        // 기존 DEPT VALUE 
                        compareStr = dept.DEPTNO;
                        DEPTdataService deptService = new DEPTdataService();
                        whereCondition = "DEPTNO = '" + Global.G_dept_update.DEPTNO + "'";
                        sql = deptService.GetUpdateSQL(Global.G_dept_update, whereCondition);

                        // 기존 DEPTNO 와 비교 다르면 에러
                        if (!compareStr.Equals(Global.G_emp_update.DEPTNO))
                        {
                            result = false;
                            reasonFail = "DEPTNO 를 변경할수 없습니다.";
                            break;
                        }

                        result = dbconn.Query(sql);
                        break;

                    case "EMP":
                        // 기존 EMP VALUE 
                        compareStr = emp.EMPNO;
                        EMPdataService empService = new EMPdataService();
                        whereCondition = "EMPNO = '" + Global.G_emp_update.EMPNO + "'";
                        sql = empService.GetUpdateSQL(Global.G_emp_update, whereCondition);

                        // 기존 EMPNO 와 비교 다르면 에러
                        if (!compareStr.Equals(Global.G_emp_update.EMPNO))
                        {
                            result = false;
                            reasonFail = "EMPNO를 변경할수 없습니다.";
                            break;
                        }

                        result = dbconn.Query(sql);
                        break;

                    case "SALGRADE":
                        // 기존 SALGRADE VALUE 
                        compareStr = salgrade.GRADE;
                        SALGRADEdataService salgradeService = new SALGRADEdataService();
                        whereCondition = "GRADE = '" + Global.G_salgrade_update.GRADE + "'";
                        sql = salgradeService.GetUpdateSQL(Global.G_salgrade_update, whereCondition);

                        // 기존 GRADE 와 비교 다르면 에러
                        if (!compareStr.Equals(Global.G_salgrade_update.GRADE))
                        {
                            result = false;
                            reasonFail = "GRADE 를 변경할수 없습니다.";
                            break;
                        }

                        result = dbconn.Query(sql);
                        break;

                    case "":
                        MessageBox.Show("Table 을 선택하세요", "Error");
                        break;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (!result)
                {
                    MessageBox.Show(reasonFail, "Error");
                }
                else
                {
                    MessageBox.Show("성공", "Success");
                }
                Global.G_bonus_update = null;
                Global.G_dept_update = null;
                Global.G_emp_update = null;
                Global.G_salgrade_update = null;
                setButtonVisible();

                new QueryLog().Logging(cbTable.Text, sql, result.ToString() ,QueryLog.LOGTYPE.TEXT);
                sql = string.Empty;
                btnSelect.PerformClick();
            }
        }
        private void btnNewdata_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                switch (cbTable.Text)
                {
                    case "BONUS":
                        Global.G_list_bonus.Add(new BONUS());
                        dataGridView1.DataSource = Global.G_list_bonus;
                        BONUS bonus = new BONUS(setItem(dataGridView1.Rows[Global.G_list_bonus.Count - 1].Cells));
                        Global.G_bonus_update = bonus;
                        propertyGrid1.SelectedObject = bonus;
                        break;

                    case "DEPT":
                        Global.G_list_dept.Add(new DEPT());
                        dataGridView1.DataSource = Global.G_list_dept;
                        DEPT dept = new DEPT(setItem(dataGridView1.Rows[Global.G_list_dept.Count - 1].Cells));
                        Global.G_dept_update = dept;
                        propertyGrid1.SelectedObject = dept;
                        break;

                    case "EMP":
                        Global.G_list_emp.Add(new EMP());
                        dataGridView1.DataSource = Global.G_list_emp;
                        EMP emp = new EMP(setItem(dataGridView1.Rows[Global.G_list_emp.Count - 1].Cells));
                        Global.G_emp_update = emp;
                        propertyGrid1.SelectedObject = emp;
                        break;

                    case "SALGRADE":
                        Global.G_list_salgrade.Add(new SALGRADE());
                        dataGridView1.DataSource = Global.G_list_salgrade;
                        SALGRADE salgrade = new SALGRADE(setItem(dataGridView1.Rows[Global.G_list_salgrade.Count - 1].Cells));
                        Global.G_salgrade_update = salgrade;
                        propertyGrid1.SelectedObject = salgrade;
                        break;

                    case "":
                        MessageBox.Show("Table 을 선택하세요", "Error");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        { 
            switch (cbTable.Text)
            {
                case "BONUS":
                    bonus = new BONUS(setItem(dataGridView1.Rows[e.RowIndex].Cells));
                    Global.G_bonus_update = bonus;
                    propertyGrid1.SelectedObject = bonus;
                    break;

                case "DEPT":
                    dept = new DEPT(setItem(dataGridView1.Rows[e.RowIndex].Cells));
                    Global.G_dept_update = dept;
                    propertyGrid1.SelectedObject = dept;
                    break;

                case "EMP":
                    emp = new EMP(setItem(dataGridView1.Rows[e.RowIndex].Cells));
                    Global.G_emp_update = emp;
                    propertyGrid1.SelectedObject = emp;
                    break;

                case "SALGRADE":
                    salgrade = new SALGRADE(setItem(dataGridView1.Rows[e.RowIndex].Cells));
                    Global.G_salgrade_update = salgrade;
                    propertyGrid1.SelectedObject = salgrade;
                    break;

                case "":
                    MessageBox.Show("Table 을 선택하세요", "Error");
                    break;
            }
            setButtonVisible();
        }
        public string[] setItem(System.Windows.Forms.DataGridViewCellCollection Cells)
        {
            try
            {
                string[] returnstr = new string[Cells.Count];
                for (int i = 0 ; i < Cells.Count ; i++)
                {
                    if (Cells[i].Value == null)
                    {
                        returnstr[i] = "";
                    }
                    else
                    {
                        returnstr[i] = Cells[i].Value.ToString();
                    }

                }
                return returnstr;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void setCombobox()
        {
            try
            {
                
                System.IO.DirectoryInfo di = null;
                if (Global.selectedDatabase != null)
                {
                    DBConnection.InitDB(Global.selectedDatabase);
                    di = new System.IO.DirectoryInfo(@"C:\Users\admin\Documents\Visual Studio 2015\Projects\Oracle11g\Oracle11g\" + Global.selectedDatabase.DB_tabledirectory);
                }
                    

                System.IO.FileInfo[] fi = di.GetFiles("*.cs");
                if (fi.Length == 0)
                    MessageBox.Show("테이블 없음");
                else
                {
                    int index = 0;
                    List<string> strlist = new List<string>();
                    for (int j = 0 ; j < fi.Length ; j++)
                    {
                        if (!fi[j].ToString().Contains("dataService"))
                        {
                            strlist.Add(fi[j].ToString());
                            index++;
                        }
                    }
                    string[] tableNameList = new string[index];
                    for (int i = 0 ; i < tableNameList.Length ; i++)
                    {
                        tableNameList[i] = strlist[i].Replace(".cs", "");
                    }
                    cbTable.Items.AddRange(tableNameList);
                }
            }
            catch
            {

            }

        }

        void setButtonVisible()
        {
            if (
                Global.G_emp_update == null && 
                Global.G_dept_update == null &&
                Global.G_salgrade_update == null &&
                Global.G_bonus_update == null
                )
            {
                btnInsert.Enabled = false;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;

            }
            else
            {
                btnInsert.Enabled = true;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
            }
        }

        private void btnPopup_Click(object sender, EventArgs e)
        {
            mainMnuSetting_Click(this, null);
        }
        private void mainMnuSetting_Click(object sender, EventArgs e)
        {
            //InsertForm f = new InsertForm(this);
            InsertForm configForm = new InsertForm(this);
            if (configForm.ShowDialog() == DialogResult.OK)
            {

            }
            //configForm.ShowDialog();

            configForm.Dispose();
            configForm = null;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            switch (cbTable.Text)
            {
                case "BONUS":
                    BONUS bonus = new BONUS(setItem(dataGridView1.Rows[e.RowIndex].Cells));
                    Global.G_bonus_update = bonus;
                    propertyGrid1.SelectedObject = bonus;
                    break;

                case "DEPT":
                    DEPT dept = new DEPT(setItem(dataGridView1.Rows[e.RowIndex].Cells));
                    Global.G_dept_update = dept;
                    propertyGrid1.SelectedObject = dept;
                    break;

                case "EMP":
                    EMP emp = new EMP(setItem(dataGridView1.Rows[e.RowIndex].Cells));
                    Global.G_emp_update = emp;
                    propertyGrid1.SelectedObject = emp;
                    break;

                case "SALGRADE":
                    SALGRADE salgrade = new SALGRADE(setItem(dataGridView1.Rows[e.RowIndex].Cells));
                    Global.G_salgrade_update = salgrade;
                    propertyGrid1.SelectedObject = salgrade;
                    break;

                case "":
                    MessageBox.Show("Table 을 선택하세요", "Error");
                    break;
            }
        }
    }
}
