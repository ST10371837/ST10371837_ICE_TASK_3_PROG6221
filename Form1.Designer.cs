using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CafeApp
{
    public partial class MainForm : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBox1 = new ComboBox();
            numericUpDown1 = new NumericUpDown();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(135, 83);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(405, 84);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 27);
            numericUpDown1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(689, 85);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(689, 156);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 3;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(numericUpDown1);
            Controls.Add(comboBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBox1;
        private NumericUpDown numericUpDown1;
        private Button button1;
        private Button button2;

        private Dictionary<string, double> menu = new Dictionary<string, double>()
        {
            { "Coffee", 2.50 },
            { "Tea", 1.75 },
            { "Sandwich", 5.00 },
            { "Cake", 3.50 }
        };

        private Dictionary<string, int> order = new Dictionary<string, int>();

        public MainForm()
        {
            InitializeComponent();

            foreach (var item in menu.Keys)
            {
                comboBoxItems.Items.Add(item);
            }
        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            string selectedItem = comboBoxItems.SelectedItem.ToString();
            int quantity = (int)numericUpDownQuantity.Value;

            if (order.ContainsKey(selectedItem))
            {
                order[selectedItem] += quantity;
            }
            else
            {
                order.Add(selectedItem, quantity);
            }

            MessageBox.Show($"{quantity} {selectedItem}(s) added to the order.");
        }

        private void btnShowReceipt_Click(object sender, EventArgs e)
        {
            string receipt = "Receipt:\n";

            double total = 0;

            foreach (var item in order)
            {
                double price = menu[item.Key];
                double itemTotal = price * item.Value;
                total += itemTotal;

                receipt += $"{item.Key}: {item.Value} x ${price} = ${itemTotal}\n";
            }

            receipt += $"\nTotal: ${total}";

            MessageBox.Show(receipt, "Receipt");
        }
    }
} 
    
