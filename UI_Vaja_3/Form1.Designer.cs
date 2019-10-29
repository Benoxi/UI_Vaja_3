namespace UI_Vaja_3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CanvasBoard = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.coorX = new System.Windows.Forms.Label();
            this.coorY = new System.Windows.Forms.Label();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.btnVekt = new System.Windows.Forms.Button();
            this.vektBox = new System.Windows.Forms.TextBox();
            this.symBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.symNumBox = new System.Windows.Forms.TextBox();
            this.layerBox = new System.Windows.Forms.TextBox();
            this.alphaBox = new System.Windows.Forms.TextBox();
            this.etaBox = new System.Windows.Forms.TextBox();
            this.btnTrain = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnGuess = new System.Windows.Forms.Button();
            this.lbNetwork = new System.Windows.Forms.Label();
            this.btnDirect = new System.Windows.Forms.Button();
            this.fileBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CanvasBoard
            // 
            this.CanvasBoard.BackColor = System.Drawing.SystemColors.Window;
            this.CanvasBoard.Location = new System.Drawing.Point(50, 50);
            this.CanvasBoard.Name = "CanvasBoard";
            this.CanvasBoard.Size = new System.Drawing.Size(280, 280);
            this.CanvasBoard.TabIndex = 0;
            this.CanvasBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownEvent);
            this.CanvasBoard.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
            this.CanvasBoard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpEvent);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 370);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Coordinate X : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 394);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Coordinate Y : ";
            // 
            // coorX
            // 
            this.coorX.AutoSize = true;
            this.coorX.Location = new System.Drawing.Point(129, 370);
            this.coorX.Name = "coorX";
            this.coorX.Size = new System.Drawing.Size(0, 13);
            this.coorX.TabIndex = 3;
            // 
            // coorY
            // 
            this.coorY.AutoSize = true;
            this.coorY.Location = new System.Drawing.Point(128, 394);
            this.coorY.Name = "coorY";
            this.coorY.Size = new System.Drawing.Size(0, 13);
            this.coorY.TabIndex = 4;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Location = new System.Drawing.Point(255, 336);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.DeleteBtn.TabIndex = 5;
            this.DeleteBtn.Text = "DELETE";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // btnVekt
            // 
            this.btnVekt.Location = new System.Drawing.Point(47, 336);
            this.btnVekt.Name = "btnVekt";
            this.btnVekt.Size = new System.Drawing.Size(122, 23);
            this.btnVekt.TabIndex = 6;
            this.btnVekt.Text = "VECTORIZE";
            this.btnVekt.UseVisualStyleBackColor = true;
            this.btnVekt.Click += new System.EventHandler(this.btnVekt_Click);
            // 
            // vektBox
            // 
            this.vektBox.Location = new System.Drawing.Point(75, 424);
            this.vektBox.Name = "vektBox";
            this.vektBox.Size = new System.Drawing.Size(184, 20);
            this.vektBox.TabIndex = 7;
            this.vektBox.Text = "100";
            // 
            // symBox
            // 
            this.symBox.Location = new System.Drawing.Point(50, 24);
            this.symBox.Name = "symBox";
            this.symBox.Size = new System.Drawing.Size(46, 20);
            this.symBox.TabIndex = 8;
            this.symBox.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 427);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "N :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 462);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "SYMBOLS :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 497);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "HIDDEN LAYER :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 535);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "ALPHA :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 573);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "ETA :";
            // 
            // symNumBox
            // 
            this.symNumBox.Location = new System.Drawing.Point(117, 459);
            this.symNumBox.Name = "symNumBox";
            this.symNumBox.Size = new System.Drawing.Size(142, 20);
            this.symNumBox.TabIndex = 15;
            this.symNumBox.Text = "2";
            // 
            // layerBox
            // 
            this.layerBox.Location = new System.Drawing.Point(143, 494);
            this.layerBox.Name = "layerBox";
            this.layerBox.Size = new System.Drawing.Size(116, 20);
            this.layerBox.TabIndex = 16;
            this.layerBox.Text = "16";
            // 
            // alphaBox
            // 
            this.alphaBox.Location = new System.Drawing.Point(102, 532);
            this.alphaBox.Name = "alphaBox";
            this.alphaBox.Size = new System.Drawing.Size(157, 20);
            this.alphaBox.TabIndex = 17;
            this.alphaBox.Text = "0.5";
            // 
            // etaBox
            // 
            this.etaBox.Location = new System.Drawing.Point(87, 570);
            this.etaBox.Name = "etaBox";
            this.etaBox.Size = new System.Drawing.Size(172, 20);
            this.etaBox.TabIndex = 18;
            this.etaBox.Text = "0.15";
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(265, 424);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(65, 166);
            this.btnTrain.TabIndex = 19;
            this.btnTrain.Text = "TRAIN";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(265, 596);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(65, 53);
            this.btnStop.TabIndex = 20;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnGuess
            // 
            this.btnGuess.Location = new System.Drawing.Point(47, 596);
            this.btnGuess.Name = "btnGuess";
            this.btnGuess.Size = new System.Drawing.Size(212, 53);
            this.btnGuess.TabIndex = 21;
            this.btnGuess.Text = "GUESS";
            this.btnGuess.UseVisualStyleBackColor = true;
            this.btnGuess.Click += new System.EventHandler(this.btnGuess_Click);
            // 
            // lbNetwork
            // 
            this.lbNetwork.AutoSize = true;
            this.lbNetwork.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNetwork.Location = new System.Drawing.Point(97, 722);
            this.lbNetwork.Name = "lbNetwork";
            this.lbNetwork.Size = new System.Drawing.Size(170, 31);
            this.lbNetwork.TabIndex = 22;
            this.lbNetwork.Text = "NOT HERE! ";
            // 
            // btnDirect
            // 
            this.btnDirect.Location = new System.Drawing.Point(265, 808);
            this.btnDirect.Name = "btnDirect";
            this.btnDirect.Size = new System.Drawing.Size(107, 23);
            this.btnDirect.TabIndex = 23;
            this.btnDirect.Text = "DIRECT TRAIN";
            this.btnDirect.UseVisualStyleBackColor = true;
            this.btnDirect.Click += new System.EventHandler(this.btnDirect_Click);
            // 
            // fileBox
            // 
            this.fileBox.Location = new System.Drawing.Point(47, 810);
            this.fileBox.Name = "fileBox";
            this.fileBox.Size = new System.Drawing.Size(212, 20);
            this.fileBox.TabIndex = 24;
            this.fileBox.Text = "example_of_1_and_2.txt";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(384, 843);
            this.Controls.Add(this.fileBox);
            this.Controls.Add(this.btnDirect);
            this.Controls.Add(this.lbNetwork);
            this.Controls.Add(this.btnGuess);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnTrain);
            this.Controls.Add(this.etaBox);
            this.Controls.Add(this.alphaBox);
            this.Controls.Add(this.layerBox);
            this.Controls.Add(this.symNumBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.symBox);
            this.Controls.Add(this.vektBox);
            this.Controls.Add(this.btnVekt);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.coorY);
            this.Controls.Add(this.coorX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CanvasBoard);
            this.Name = "Form1";
            this.Text = "Neural Network";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel CanvasBoard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label coorX;
        private System.Windows.Forms.Label coorY;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button btnVekt;
        private System.Windows.Forms.TextBox vektBox;
        private System.Windows.Forms.TextBox symBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox symNumBox;
        private System.Windows.Forms.TextBox layerBox;
        private System.Windows.Forms.TextBox alphaBox;
        private System.Windows.Forms.TextBox etaBox;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnGuess;
        private System.Windows.Forms.Label lbNetwork;
        private System.Windows.Forms.Button btnDirect;
        private System.Windows.Forms.TextBox fileBox;
    }
}

