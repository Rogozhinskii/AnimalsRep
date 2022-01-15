using AnimalsLib.Interfaces;
using OfficeOpenXml;

namespace AnimalsLib.Savers
{
    /// <summary>
    /// Выполняет сохранение списка объектов в excel
    /// </summary>
    public class XlsxSaver:ISaver
    {
        private readonly int _firtDataRow = 2;
        private readonly int _headersRow = 1;
        public XlsxSaver()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        /// <summary>
        /// Создает книгу эксель и лист с данными. Заполняет лист данными их коллекции 
        /// </summary>
        /// <param name="animals">коллекция животных</param>
        /// <returns></returns>
        private ExcelPackage PrepareData(List<IAnimal> animals)
        {
            var package=new ExcelPackage();
            var sheet = package.Workbook.Worksheets.Add("DataSheet");
            FillHeaders(sheet, animals.FirstOrDefault());
            var _currentRow = _firtDataRow;
            foreach (var item in animals)
            {
                Type type = item.GetType();
                for (int i = 0; i < type.GetProperties().Length; i++)
                {                    
                    sheet.Cells[_currentRow,i+1].Value=type.GetProperties()[i].GetValue(item);
                }
                _currentRow++;
            }
            return package;
        }
        /// <summary>
        /// Формирует строку заголовков
        /// </summary>
        /// <param name="ws">лист на который заносятся заголовки</param>
        /// <param name="animal">"Прототип" объекта который будет записываться в excel для формирования заголовкой по принципу Свойство=Заголовок</param>
        private void FillHeaders(ExcelWorksheet ws, IAnimal animal)
        {
            if (animal == null) return;
            var type=animal.GetType();     
            var properies=type.GetProperties();
            for (int i = 0; i < properies.Length; i++)
            {
                ws.Cells[_headersRow, i + 1].Value = properies[i].Name;
            }
            
        }

       
        public void SaveData(string savePath, List<IAnimal> animals)
        {
            var package=PrepareData(animals);
            package.SaveAs($"{savePath}.xlsx");
        }
    }
}
