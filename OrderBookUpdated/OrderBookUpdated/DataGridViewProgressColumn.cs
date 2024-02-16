
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace OrderBookUpdated

{
    public class DataGridViewProgressColumn : DataGridViewImageColumn
    {
        public float? LargestTotal { get; private set; } 
        public string Side {  get; private set; }

        public DataGridViewProgressColumn()
        {
            CellTemplate = new DataGridViewProgressCell();
        }

        // Method to set LargestTotal for the cell template
        public void SetLargestTotal(float largestTotal)
        {
            this.LargestTotal = largestTotal;
        }
        public void SetSide(string side)
        {
            this.Side = side;
        }
    }


    class DataGridViewProgressCell : DataGridViewImageCell
    {
        private DataGridViewProgressColumn _parentCol;

        // Used to make custom cell consistent with a DataGridViewImageCell
        static Image emptyImage;
        static DataGridViewProgressCell()
        {
            emptyImage = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }
            
    

        public DataGridViewProgressCell()
        {
            this.ValueType = typeof(int);
        }

        // Method required to make the Progress Cell consistent with the default Image Cell. 
        // The default Image Cell assumes an Image as a value, although the value of the Progress Cell is an int.
        protected override object GetFormattedValue(object value,
                            int rowIndex, ref DataGridViewCellStyle cellStyle,
                            TypeConverter valueTypeConverter,
                            TypeConverter formattedValueTypeConverter,
                            DataGridViewDataErrorContexts context)
        {
            return emptyImage;
        }
        protected override void Paint(System.Drawing.Graphics g, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            try
            {
                if (value != null)
                {
                    int progressVal = (int)value;
                    if (this.OwningColumn is DataGridViewProgressColumn Owner)
                    {
                        float percentage = 1000000.0f;

                        if (Owner.LargestTotal != null && Owner.LargestTotal != 0)
                        {
                            percentage = progressVal / (float)Owner.LargestTotal;
                        } // Need to convert to float before division; otherwise C# returns int which is 0 for anything but 100%.


                        Brush backColorBrush = new SolidBrush(cellStyle.BackColor);
                        Brush foreColorBrush = new SolidBrush(cellStyle.ForeColor);
                        // Draws the cell grid
                        base.Paint(g, clipBounds, cellBounds,
                         rowIndex, cellState, value, formattedValue, errorText,
                         cellStyle, advancedBorderStyle, (paintParts & ~DataGridViewPaintParts.ContentForeground));
                        if (percentage > 0.0)
                        {
                            // Draw the progress bar and the text
                            if (Owner.Side == "Buy")
                            {
                                g.FillRectangle(new SolidBrush(Color.FromArgb(203, 235, 108)), cellBounds.X + 2, cellBounds.Y + 2, Convert.ToInt32((percentage * cellBounds.Width - 4)), cellBounds.Height - 4);
                            }
                            else
                            {
                                g.FillRectangle(new SolidBrush(Color.FromArgb(255, 117, 117)), cellBounds.X + 2, cellBounds.Y + 2, Convert.ToInt32((percentage * cellBounds.Width - 4)), cellBounds.Height - 4);
                            }

                            g.DrawString(progressVal.ToString(), cellStyle.Font, foreColorBrush, cellBounds.X + (cellBounds.Width / 2) - 5, cellBounds.Y + 2);


                        }
                        else
                        {
                            // draw the text
                            if (this.DataGridView.CurrentRow.Index == rowIndex)
                                g.DrawString(progressVal.ToString(), cellStyle.Font, new SolidBrush(cellStyle.SelectionForeColor), cellBounds.X + 6, cellBounds.Y + 2);
                            else
                                g.DrawString(progressVal.ToString(), cellStyle.Font, foreColorBrush, cellBounds.X + 6, cellBounds.Y + 2);
                        }
                    }
                }
            }
            catch (Exception e) { }

        }
    }
}