using System.Data;
using System.Xml.Serialization;

namespace Прога
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Создание DataSet
            DataSet dataSet = new DataSet();

            // Создание таблиц
            DataTable departmentTable = new DataTable("Department");
            DataTable positionTable = new DataTable("Position");
            DataTable employeeTable = new DataTable("Employee");
            DataTable vacationTypeTable = new DataTable("VacationType");
            DataTable workplaceTable = new DataTable("Workplace");
            DataTable vacationTable = new DataTable("Vacation");

            // Добавление столбцов в таблицу Department
            departmentTable.Columns.Add("department_id", typeof(int));
            departmentTable.Columns.Add("department_name", typeof(string));

            // Добавление столбцов в таблицу Position
            positionTable.Columns.Add("position_id", typeof(int));
            positionTable.Columns.Add("position_name", typeof(string));

            // Добавление столбцов в таблицу Employee
            employeeTable.Columns.Add("employee_id", typeof(int));
            employeeTable.Columns.Add("employee_first_name", typeof(string));
            employeeTable.Columns.Add("employee_second_name", typeof(string));
            employeeTable.Columns.Add("date_of_birth", typeof(DateTime));
            employeeTable.Columns.Add("INN", typeof(string));
            employeeTable.Columns.Add("pension_certificate_number", typeof(string));
            employeeTable.Columns.Add("passport_series", typeof(string));
            employeeTable.Columns.Add("passport_number", typeof(string));


            // Добавление столбцов в таблицу VacationType
            vacationTypeTable.Columns.Add("vacation_type_id", typeof(int));
            vacationTypeTable.Columns.Add("vacation_type_name", typeof(string));

            // Добавление столбцов в таблицу Workplace
            workplaceTable.Columns.Add("work_id", typeof(int));
            workplaceTable.Columns.Add("employee_id", typeof(int));
            workplaceTable.Columns.Add("position_id", typeof(int));
            workplaceTable.Columns.Add("department_id", typeof(int));
            workplaceTable.Columns.Add("start_date", typeof(DateTime));
            workplaceTable.Columns.Add("end_date", typeof(DateTime));

            // Добавление столбцов в таблицу Vacation
            vacationTable.Columns.Add("vacation_id", typeof(int));
            vacationTable.Columns.Add("vacation_type_id", typeof(int));
            vacationTable.Columns.Add("work_id", typeof(int));
            vacationTable.Columns.Add("start_date", typeof(DateTime));
            vacationTable.Columns.Add("end_date", typeof(DateTime));

            // Установка автоинкремента и уникальности для department_id
            departmentTable.Columns["department_id"].AutoIncrement = true;
            departmentTable.Columns["department_id"].AutoIncrementSeed = 1;
            departmentTable.Columns["department_id"].AutoIncrementStep = 1;
            departmentTable.Columns["department_id"].Unique = true;

            // Установка автоинкремента и уникальности для position_id
            positionTable.Columns["position_id"].AutoIncrement = true;
            positionTable.Columns["position_id"].AutoIncrementSeed = 1;
            positionTable.Columns["position_id"].AutoIncrementStep = 1;
            positionTable.Columns["position_id"].Unique = true;

            // Установка автоинкремента и уникальности для employee_id
            employeeTable.Columns["employee_id"].AutoIncrement = true;
            employeeTable.Columns["employee_id"].AutoIncrementSeed = 1;
            employeeTable.Columns["employee_id"].AutoIncrementStep = 1;
            employeeTable.Columns["employee_id"].Unique = true;

            // Установка автоинкремента и уникальности для vacation_type_id
            vacationTypeTable.Columns["vacation_type_id"].AutoIncrement = true;
            vacationTypeTable.Columns["vacation_type_id"].AutoIncrementSeed = 1;
            vacationTypeTable.Columns["vacation_type_id"].AutoIncrementStep = 1;
            vacationTypeTable.Columns["vacation_type_id"].Unique = true;

            // Установка автоинкремента и уникальности для work_id
            workplaceTable.Columns["work_id"].AutoIncrement = true;
            workplaceTable.Columns["work_id"].AutoIncrementSeed = 1;
            workplaceTable.Columns["work_id"].AutoIncrementStep = 1;
            workplaceTable.Columns["work_id"].Unique = true;

            // Установка автоинкремента и уникальности для vacation_id
            vacationTable.Columns["vacation_id"].AutoIncrement = true;
            vacationTable.Columns["vacation_id"].AutoIncrementSeed = 1;
            vacationTable.Columns["vacation_id"].AutoIncrementStep = 1;
            vacationTable.Columns["vacation_id"].Unique = true;


            // Добавление таблиц в DataSet
            dataSet.Tables.Add(departmentTable);
            dataSet.Tables.Add(positionTable);
            dataSet.Tables.Add(employeeTable);
            dataSet.Tables.Add(vacationTypeTable);
            dataSet.Tables.Add(workplaceTable);
            dataSet.Tables.Add(vacationTable);

            // Установка первичного ключа для таблицы Department
            departmentTable.PrimaryKey = new DataColumn[] { departmentTable.Columns["department_id"] };

            // Установка первичного ключа для таблицы Position
            positionTable.PrimaryKey = new DataColumn[] { positionTable.Columns["position_id"] };

            // Установка первичного ключа для таблицы Employee
            employeeTable.PrimaryKey = new DataColumn[] { employeeTable.Columns["employee_id"] };

            // Установка первичного ключа для таблицы VacationType
            vacationTypeTable.PrimaryKey = new DataColumn[] { vacationTypeTable.Columns["vacation_type_id"] };

            // Установка первичного ключа для таблицы Workplace
            workplaceTable.PrimaryKey = new DataColumn[] { workplaceTable.Columns["work_id"] };

            // Установка первичного ключа для таблицы Vacation
            vacationTable.PrimaryKey = new DataColumn[] { vacationTable.Columns["vacation_id"] };

            // Создание внешнего ключа между таблицами Workplace и Department
            DataRelation workplaceDepartmentRelation = new DataRelation(
                "FK_Workplace_Department", // Имя отношения
                departmentTable.Columns["department_id"], // Колонка, на которую ссылается внешний ключ (в таблице Workplace)
                workplaceTable.Columns["department_id"] // Колонка, на которую ссылается первичный ключ (в таблице Department)
            );

            // Добавление внешнего ключа в DataSet
            dataSet.Relations.Add(workplaceDepartmentRelation);

            // Создание внешнего ключа между таблицами Workplace и Position
            DataRelation workplacePositionRelation = new DataRelation(
                "FK_Workplace_Position", // Имя отношения
                positionTable.Columns["position_id"], // Колонка, на которую ссылается внешний ключ (в таблице Workplace)
                workplaceTable.Columns["position_id"] // Колонка, на которую ссылается первичный ключ (в таблице Position)
            );

            // Добавление внешнего ключа в DataSet
            dataSet.Relations.Add(workplacePositionRelation);

            // Создание внешнего ключа между таблицами Vacation и VacationType
            DataRelation vacationVacationTypeRelation = new DataRelation(
                "FK_Vacation_VacationType", // Имя отношения
                vacationTypeTable.Columns["vacation_type_id"], // Колонка, на которую ссылается внешний ключ (в таблице Vacation)
                vacationTable.Columns["vacation_type_id"] // Колонка, на которую ссылается первичный ключ (в таблице VacationType)
            );

            // Добавление внешнего ключа в DataSet
            dataSet.Relations.Add(vacationVacationTypeRelation);

            // Создание внешнего ключа между таблицами Vacation и Workplace
            DataRelation vacationWorkplaceRelation = new DataRelation(
                "FK_Vacation_Workplace", // Имя отношения
                workplaceTable.Columns["work_id"], // Колонка, на которую ссылается внешний ключ (в таблице Vacation)
                vacationTable.Columns["work_id"] // Колонка, на которую ссылается первичный ключ (в таблице Workplace)
            );

            // Добавление внешнего ключа в DataSet
            dataSet.Relations.Add(vacationWorkplaceRelation);

            // Создание внешнего ключа между таблицами Employee и Workplace
            DataRelation employeeWorkplaceRelation = new DataRelation(
                "FK_Employee_Workplace", // Имя отношения
                employeeTable.Columns["employee_id"], // Колонка, на которую ссылается внешний ключ (в таблице Workplace)
                workplaceTable.Columns["employee_id"] // Колонка, на которую ссылается первичный ключ (в таблице Employee)
            );

            // Добавление внешнего ключа в DataSet
            dataSet.Relations.Add(employeeWorkplaceRelation);


            // Заполнение данными (пример)
            departmentTable.Rows.Add(null, "HR");
            departmentTable.Rows.Add(null, "Finance");
            positionTable.Rows.Add(null, "Manager");
            positionTable.Rows.Add(null, "Developer");
            employeeTable.Rows.Add(null, "John Doe", DateTime.Parse("1990-01-15"), "1234567890", "P123456", "123 Main St");
            workplaceTable.Rows.Add(null, null, null, null, DateTime.Parse("2022-01-01"), null);
            vacationTypeTable.Rows.Add(null, "Paid Vacation");
            vacationTable.Rows.Add(null, null, null, DateTime.Parse("2022-06-01"), DateTime.Parse("2022-06-15"));

            // Свяжите combinedTable с DataGridView
            dataGridView1.DataSource = employeeTable;

        }
    }
}