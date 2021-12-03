
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System.Collections.Generic;
using TIP_var12BusinessLogic.HelperClass;

namespace TIP_var12BusinessLogic.BusinessLogic
{
    class SaveToPdf
    {
		public static void CreateDocCars(PdfInfo info)
		{
			Document document = new Document();
			DefineStyles(document);
			Section section = document.AddSection();
			Paragraph paragraph = section.AddParagraph(info.Title);
			paragraph.Format.SpaceAfter = "1cm";
			paragraph.Format.Alignment = ParagraphAlignment.Center;
			paragraph.Style = "NormalTitle";
			paragraph = section.AddParagraph($"с {info.DateFrom.ToShortDateString()} по {info.DateTo.ToShortDateString()}");
			paragraph.Format.SpaceAfter = "1cm";
			paragraph.Format.Alignment = ParagraphAlignment.Center;
			paragraph.Style = "Normal";
			var table = document.LastSection.AddTable();
			List<string> columns = new List<string> { "3cm", "3cm", "3cm", "2cm", "2cm", "3cm" };
			foreach (var elem in columns)
			{
				table.AddColumn(elem);
			}
			CreateRow(new PdfRowParameters
			{
				Table = table,
				Texts = new List<string> { "Код автомобиля", "Название автомобиля", "Начальный остаток", "Приход", "Расход", "Конечный остаток" },
				Style = "NormalTitle",
				ParagraphAlignment = ParagraphAlignment.Center
			});
			foreach (var cars in info.Cars)
			{
				CreateRow(new PdfRowParameters
				{
					Table = table,
					Texts = new List<string> { 
						cars.IdCars.ToString(),
						cars.CarName.ToString(),
						cars.StartBalance.ToString(),
						cars.Receipt.ToString(),
						cars.Сonsumption.ToString(),
						cars.EndBalance.ToString()
					},
					Style = "Normal",
					ParagraphAlignment = ParagraphAlignment.Left
				});
			}

			PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always)
			{
				Document = document
			};
			renderer.RenderDocument();
			renderer.PdfDocument.Save(info.FileName);
		}
		public static void CreateDocRequest(PdfInfo info)
		{
			Document document = new Document();
			DefineStyles(document);
			Section section = document.AddSection();
			Paragraph paragraph = section.AddParagraph(info.Title);
			paragraph.Format.SpaceAfter = "1cm";
			paragraph.Format.Alignment = ParagraphAlignment.Center;
			paragraph.Style = "NormalTitle";
			paragraph = section.AddParagraph($"с {info.DateFrom.ToShortDateString()} по {info.DateTo.ToShortDateString()}");
			paragraph.Format.SpaceAfter = "1cm";
			paragraph.Format.Alignment = ParagraphAlignment.Center;
			paragraph.Style = "Normal";
			var table = document.LastSection.AddTable();
			List<string> columns = new List<string> { "3cm", "3cm", "3cm", "2cm", "2cm", "3cm" };
			foreach (var elem in columns)
			{
				table.AddColumn(elem);
			}
			CreateRow(new PdfRowParameters
			{
				Table = table,
				Texts = new List<string> { "Заявка", "Автомобиль/услуга", "Количество ", "Себестоимость", "Сумма продажи", "Прибыль" },
				Style = "NormalTitle",
				ParagraphAlignment = ParagraphAlignment.Center
			});
			foreach (var req in info.Request)
			{
				CreateRow(new PdfRowParameters
				{
					Table = table,
					Texts = new List<string> {
						req.Request.ToString(),
						req.Item.ToString(),
						req.Count.ToString(),
						req.Purchaseprice.ToString(),
						req.Retailprice.ToString(),
						req.Proceeds.ToString()
					},
					Style = "Normal",
					ParagraphAlignment = ParagraphAlignment.Left
				});
			}
			PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always)
			{
				Document = document
			};
			renderer.RenderDocument();
			renderer.PdfDocument.Save(info.FileName);
		}
			/// <summary>
			/// Создание стилей для документа
			/// </summary>
			/// <param name="document"></param>
			private static void DefineStyles(Document document)
		{
			Style style = document.Styles["Normal"];
			style.Font.Name = "Times New Roman";
			style.Font.Size = 14;
			style = document.Styles.AddStyle("NormalTitle", "Normal");
			style.Font.Bold = true;
		}
		/// <summary>
		/// Создание и заполнение строки
		/// </summary>
		/// <param name="rowParameters"></param>
		private static void CreateRow(PdfRowParameters rowParameters)
		{
			Row row = rowParameters.Table.AddRow();
			for (int i = 0; i < rowParameters.Texts.Count; ++i)
			{
				FillCell(new PdfCellParameters
				{
					Cell = row.Cells[i],
					Text = rowParameters.Texts[i],
					Style = rowParameters.Style,
					BorderWidth = 0.5,
					ParagraphAlignment = rowParameters.ParagraphAlignment
				});
			}
		}
		/// <summary>
		/// Заполнение ячейки
		/// </summary>
		/// <param name="cellParameters"></param>
		private static void FillCell(PdfCellParameters cellParameters)
		{
			cellParameters.Cell.AddParagraph(cellParameters.Text);
			if (!string.IsNullOrEmpty(cellParameters.Style))
			{
				cellParameters.Cell.Style = cellParameters.Style;
			}
			cellParameters.Cell.Borders.Left.Width = cellParameters.BorderWidth;
			cellParameters.Cell.Borders.Right.Width = cellParameters.BorderWidth;
			cellParameters.Cell.Borders.Top.Width = cellParameters.BorderWidth;
			cellParameters.Cell.Borders.Bottom.Width = cellParameters.BorderWidth;
			cellParameters.Cell.Format.Alignment = cellParameters.ParagraphAlignment;
			cellParameters.Cell.VerticalAlignment = VerticalAlignment.Center;
		}
	}
}
