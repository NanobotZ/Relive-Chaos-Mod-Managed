using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChaosConfigApp
{
    public class NumericUpDownColumn : DataGridViewColumn
    {
        [Category("Appearance")]
        public decimal MinimumValue { get; set; }
        [Category("Appearance")]
        public decimal MaximumValue { get; set; }
        [Category("Appearance")]
        public int EditingDecimalPlaces { get; set; }

        public NumericUpDownColumn() : base(new NumericUpDownCell())
        {
        }

        public override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }
            set
            {
                if (value != null && !value.GetType().IsAssignableFrom(typeof(NumericUpDownCell)))
                {
                    throw new InvalidCastException("Must be a NumericUpDownCell");
                }
                base.CellTemplate = value;
            }
        }

        public override object Clone()
        {
            NumericUpDownColumn copy = base.Clone() as NumericUpDownColumn;
            copy.EditingDecimalPlaces = EditingDecimalPlaces;
            copy.MaximumValue = MaximumValue;
            copy.MinimumValue = MinimumValue;
            return copy;
        }
    }

    public class NumericUpDownCell : DataGridViewTextBoxCell
    {
        public NumericUpDownCell() : base()
        {
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            NumericUpDownEditingControl ctl = DataGridView.EditingControl as NumericUpDownEditingControl;
            NumericUpDownColumn col = DataGridView.Columns[DataGridView.CurrentCell.ColumnIndex] as NumericUpDownColumn;
            Style.Format = dataGridViewCellStyle.Format;
            ctl.Minimum = col.MinimumValue;
            ctl.Maximum = col.MaximumValue;
            ctl.DecimalPlaces = col.EditingDecimalPlaces;
            ctl.Value = Convert.ToDecimal(this.Value);
            ctl.Format = dataGridViewCellStyle.Format;
        }

        public override Type EditType => typeof(NumericUpDownEditingControl);

        public override Type ValueType => typeof(float);

        public override object DefaultNewRowValue => null;
    }

    public class NumericUpDownEditingControl : NumericUpDown, IDataGridViewEditingControl
    {
        public string Format { get; set; }
        private DataGridView dataGridViewControl;
        private bool valueIsChanged = false;
        private int rowIndexNum;

        public NumericUpDownEditingControl()
            : base()
        {
        }

        public DataGridView EditingControlDataGridView
        {
            get { return dataGridViewControl; }
            set { dataGridViewControl = value; }
        }

        public object EditingControlFormattedValue
        {
            get { return Value.ToString(Format); }
            set { Value = decimal.Parse(value.ToString()); }
        }
        public int EditingControlRowIndex
        {
            get { return rowIndexNum; }
            set { rowIndexNum = value; }
        }
        public bool EditingControlValueChanged
        {
            get { return valueIsChanged; }
            set { valueIsChanged = value; }
        }

        public Cursor EditingPanelCursor
        {
            get { return base.Cursor; }
        }

        public bool RepositionEditingControlOnValueChange
        {
            get { return false; }
        }

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            Font = dataGridViewCellStyle.Font;
            ForeColor = dataGridViewCellStyle.ForeColor;
            BackColor = dataGridViewCellStyle.BackColor;
        }

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            return (keyData == Keys.Left || keyData == Keys.Right ||
                keyData == Keys.Up || keyData == Keys.Down ||
                keyData == Keys.Home || keyData == Keys.End ||
                keyData == Keys.PageDown || keyData == Keys.PageUp);
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context) => Value.ToString();

        public void PrepareEditingControlForEdit(bool selectAll)
        {
        }

        protected override void OnValueChanged(EventArgs e)
        {
            valueIsChanged = true;
            EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(e);
        }
    }
}
