using System; 
using System.Windows.Forms; 
using System.Runtime.InteropServices; 
 
namespace WFGenerator.Controls
{ 
	/// <summary> 
	/// 一个类似于 MSN Popup 的任务消息通知器 
	/// </summary> 
	public class TaskNotifier : System.Windows.Forms.Form 
	{ 
		#region Private Fields 
		private System.Windows.Forms.Label label1; 
		private System.Windows.Forms.ImageList imageList1; 
		private System.ComponentModel.IContainer components; 
		private System.Windows.Forms.Panel panel1; 
		private System.Windows.Forms.LinkLabel linkContent;		 
		private TaskState m_TaskState = TaskState.Hidden; 
		private System.Drawing.Rectangle m_maxBound; 
		private System.Windows.Forms.Timer timer1; 
 
		private CallBackHandler callback = null; 
		private System.Object m_callbackTag = null; 
 
		private bool isMouseEnter = false; 
		private bool isMouseMove = false; 
 
		private System.Collections.Hashtable m_hashButtons = null; 
		private System.Object m_skinButtonName = null; 
 
		private UnSafeDiposeHandler m_unSafeDipose; 
 
		static private TaskNotifier objTaskNotifier = new TaskNotifier(); 
		#endregion 
 
		#region Constructors 
		/// <summary> 
		/// new 
		/// </summary> 
		public TaskNotifier() 
		{ 
			this.InitializeComponent(); 
			this.timer1.Stop(); 
			//初始化工作区大小 
			System.Drawing.Rectangle rect = System.Windows.Forms.Screen.GetWorkingArea( this ); 
			this.m_maxBound = new System.Drawing.Rectangle( rect.Right - this.Width - 1, rect.Bottom - this.Height - 1, this.Width, this.Height ); 
		} 
		#endregion 
 
		#region 控件自动生成的代码 
		/// <summary> 
		/// InitializeComponent 
		/// </summary> 
		private void InitializeComponent() 
		{ 
			this.components = new System.ComponentModel.Container(); 
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(TaskNotifier)); 
			this.label1 = new System.Windows.Forms.Label(); 
			this.imageList1 = new System.Windows.Forms.ImageList(this.components); 
			this.panel1 = new System.Windows.Forms.Panel(); 
			this.linkContent = new System.Windows.Forms.LinkLabel(); 
			this.timer1 = new System.Windows.Forms.Timer(this.components); 
			this.SuspendLayout(); 
			//  
			// label1 
			//  
			this.label1.ImageIndex = 0; 
			this.label1.ImageList = this.imageList1; 
			this.label1.Location = new System.Drawing.Point(322, 10); 
			this.label1.Name = "label1"; 
			this.label1.Size = new System.Drawing.Size(18, 18); 
			this.label1.TabIndex = 0; 
			this.label1.Click += new System.EventHandler(this.label1_Click); 
			this.label1.MouseEnter += new System.EventHandler(this.label1_MouseEnter); 
			this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave); 
			//  
			// imageList1 
			//  
			this.imageList1.ImageSize = new System.Drawing.Size(18, 18); 
			//this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream"))); 
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent; 
			//  
			// panel1 
			//  
			this.panel1.BackColor = System.Drawing.Color.Transparent; 
			this.panel1.Location = new System.Drawing.Point(60, 51); 
			this.panel1.Name = "panel1"; 
			this.panel1.Size = new System.Drawing.Size(270, 19); 
			this.panel1.TabIndex = 2; 
			//  
			// linkContent 
			//  
			this.linkContent.ActiveLinkColor = System.Drawing.Color.FromArgb(((System.Byte)(204)), ((System.Byte)(0)), ((System.Byte)(0))); 
			this.linkContent.BackColor = System.Drawing.Color.Transparent; 
			this.linkContent.Location = new System.Drawing.Point(60, 14); 
			this.linkContent.Name = "linkContent"; 
			this.linkContent.Size = new System.Drawing.Size(254, 32); 
			this.linkContent.TabIndex = 3; 
			this.linkContent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft; 
			this.linkContent.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkContent_LinkClicked); 
			//  
			// timer1 
			//  
			this.timer1.Enabled = true; 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick); 
			//  
			// TaskNotifier 
			//  
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14); 
			//this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage"))); 
			this.ClientSize = new System.Drawing.Size(344, 74); 
			this.ControlBox = false; 
			this.Controls.Add(this.linkContent); 
			this.Controls.Add(this.panel1); 
			this.Controls.Add(this.label1); 
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))); 
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; 
			this.MaximizeBox = false; 
			this.MinimizeBox = false; 
			this.Name = "TaskNotifier"; 
			this.ShowInTaskbar = false; 
			this.TopMost = true; 
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TaskNotifier_MouseMove); 
			this.MouseEnter += new System.EventHandler(this.TaskNotifier_MouseEnter); 
			this.MouseLeave += new System.EventHandler(this.TaskNotifier_MouseLeave); 
			this.ResumeLayout(false); 
 
		} 
		#endregion 
 
		#region WinAPI 
		/// <summary> 
		/// 显示窗体 
		/// </summary> 
		/// <param name="hWnd"></param> 
		/// <param name="nCmdShow"></param> 
		/// <returns></returns> 
		[DllImport("user32.dll")] 
		private static extern Boolean ShowWindow( IntPtr hWnd, Int32 nCmdShow ); 
		#endregion 
 
		#region Methods 
		/// <summary> 
		/// 返回此对象的单件实例 
		/// </summary> 
		/// <returns></returns> 
		static public TaskNotifier Instance() 
		{ 
			return objTaskNotifier; 
		} 
		/// <summary> 
		/// 添加回传按钮列表 
		/// </summary> 
		/// <param name="name"></param> 
		/// <param name="controls"></param> 
		public void AddCallbackButton( System.Object name, System.Windows.Forms.Control[] controls ) 
		{ 
			if( name == null ) 
				throw new ArgumentNullException( "Name" ); 
			if ( controls == null ) 
				throw new ArgumentNullException( "Controls" ); 
 
			if( !this.CallBackButtons.Contains( name ) && controls.Length > 0 ) 
			{ 
				System.EventHandler evt = new EventHandler( this.callBackButton_Click ); 
				foreach( System.Windows.Forms.Control callBackButton in controls ) 
				{ 
					callBackButton.Click += evt; 
				} 
				this.CallBackButtons.Add( name, controls ); 
			} 
		} 
		/// <summary> 
		/// callBackButton_Click 
		/// </summary> 
		/// <param name="sender"></param> 
		/// <param name="e"></param> 
		private void callBackButton_Click(object sender, EventArgs e) 
		{ 
			this.Hide(); 
		} 
		/// <summary> 
		/// 当移至上面时改变时样式 
		/// </summary> 
		/// <param name="sender"></param> 
		/// <param name="e"></param> 
		private void label1_MouseEnter(object sender, System.EventArgs e) 
		{ 
			this.label1.ImageIndex = 1; 
		} 
		/// <summary> 
		/// 当离开时还原其样式 
		/// </summary> 
		/// <param name="sender"></param> 
		/// <param name="e"></param> 
		private void label1_MouseLeave(object sender, System.EventArgs e) 
		{ 
			this.label1.ImageIndex = 0; 
		} 
		/// <summary> 
		/// 单击事件 
		/// </summary> 
		/// <param name="sender"></param> 
		/// <param name="e"></param> 
		private void label1_Click(object sender, System.EventArgs e) 
		{ 
			this.Hide(); 
		}		 
		/// <summary> 
		/// 在窗体内移动 
		/// </summary> 
		/// <param name="sender"></param> 
		/// <param name="e"></param> 
		private void TaskNotifier_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e) 
		{ 
			this.isMouseEnter = true; 
			this.isMouseMove = true; 
		} 
		/// <summary> 
		/// 进入此窗体 
		/// </summary> 
		/// <param name="sender"></param> 
		/// <param name="e"></param> 
		private void TaskNotifier_MouseEnter(object sender, System.EventArgs e) 
		{ 
			this.isMouseEnter = true; 
			this.isMouseMove = true; 
		} 
		/// <summary> 
		/// 离开此窗体 
		/// </summary> 
		/// <param name="sender"></param> 
		/// <param name="e"></param> 
		private void TaskNotifier_MouseLeave(object sender, System.EventArgs e) 
		{ 
			this.isMouseEnter = false; 
			this.isMouseMove = false; 
		} 
		/// <summary> 
		/// timer1_Tick 
		/// </summary> 
		/// <param name="sender"></param> 
		/// <param name="e"></param> 
		private void timer1_Tick(object sender, System.EventArgs e) 
		{ 
			switch( this.CurrentTaskState ) 
			{ 
				case TaskState.Visible: 
					this.timer1.Stop(); 
					this.timer1.Interval = 100; 
 
					if( !( this.isMouseEnter && this.isMouseMove ) ) 
						this.CurrentTaskState = TaskState.Disappearing; 
 
					this.timer1.Start(); 
					break; 
				case TaskState.Appearing: 
					if( this.Height <= this.m_maxBound.Height - 12 ) 
						this.SetBounds( this.m_maxBound.X, this.Top - 12, this.m_maxBound.Width, this.Height + 12 ); 
					else 
					{ 
						this.timer1.Stop(); 
						this.SetBounds( this.m_maxBound.X, this.m_maxBound.Y, this.m_maxBound.Width, this.m_maxBound.Height ); 
						this.CurrentTaskState = TaskState.Visible; 
						this.timer1.Interval = 5000; 
						this.timer1.Start(); 
					} 
					break; 
				case TaskState.Disappearing: 
					if ( this.isMouseEnter && this.isMouseMove ) 
						this.CurrentTaskState = TaskState.Appearing; 
					else 
					{ 
						if( this.Top <= this.m_maxBound.Bottom - 12 ) 
							this.SetBounds( this.m_maxBound.X, this.Top + 12, this.m_maxBound.Width, this.Height - 12 ); 
						else 
						{ 
							this.Hide(); 
							this.OnUnSafeDispose( this.m_callbackTag ); 
						} 
					} 
					break; 
			} 
		} 
		/// <summary> 
		/// 显示窗体 
		/// </summary> 
		/// <param name="str">要显示的内容</param> 
		public void Show( System.String str ) 
		{ 
			this.Show( "", str, null, null, null ); 
		} 
		/// <summary> 
		/// 显示窗体 
		/// </summary> 
		/// <param name="str">要显示的内容</param> 
		/// <param name="tag">设置此Popup的相关数据对象</param> 
		/// <param name="callback">当单击显示的内容时的回调事件</param> 
		public void Show( System.String str, System.Object tag, CallBackHandler callback ) 
		{ 
			this.Show( "", str, tag, callback, null ); 
		} 
		/// <summary> 
		/// 显示窗体 
		/// </summary> 
		/// <param name="skinButtonName">自定义按钮skin名称</param> 
		/// <param name="str">要显示的内容</param> 
		/// <param name="tag">设置此Popup的相关数据对象</param> 
		/// <param name="callback">当单击显示的内容时的回调事件</param> 
		/// <param name="unSafeDispose">当Popup自动关闭时引发的事件</param> 
		public void Show( System.Object skinButtonName, System.String str, System.Object tag, CallBackHandler callback, UnSafeDiposeHandler unSafeDispose ) 
		{ 
			if( this.CurrentSkinButtonName != skinButtonName ) 
			{ 
				this.CurrentSkinButtonName = skinButtonName; 
				this.panel1.Controls.Clear(); 
				if( skinButtonName != null ) 
				{ 
					System.Windows.Forms.Control[] ctls = this.CallBackButtons[ skinButtonName ] as System.Windows.Forms.Control[]; 
					if( ctls != null && ctls.Length > 0 ) 
					{ 
						System.Int32 width = 0; 
						foreach( System.Windows.Forms.Control ctl in ctls ) 
						{ 
							ctl.Location = new System.Drawing.Point( width, 0 ); 
							width += ctl.Size.Width; 
						} 
						this.panel1.Controls.AddRange( ctls ); 
					} 
				} 
			} 
			this.linkContent.Text = str; 
 
			switch( this.CurrentTaskState ) 
			{ 
				case TaskState.Hidden: 
					this.CurrentTaskState = TaskState.Appearing; 
					this.SetBounds( this.m_maxBound.X, this.m_maxBound.Y + this.m_maxBound.Height, this.m_maxBound.Width, 0 ); 
					ShowWindow( this.Handle, 4 ); 
					this.timer1.Interval = 100; 
					this.timer1.Start(); 
					break; 
				case TaskState.Visible: 
					this.timer1.Stop(); 
					this.timer1.Interval = 5000; 
					this.timer1.Start(); 
					this.OnUnSafeDispose( this.m_callbackTag ); 
					break; 
				case TaskState.Disappearing: 
					this.timer1.Stop(); 
					this.CurrentTaskState = TaskState.Visible; 
					this.SetBounds( this.m_maxBound.X, this.m_maxBound.Y, this.m_maxBound.Width, this.m_maxBound.Height ); 
					this.timer1.Interval = 5000; 
					this.timer1.Start(); 
					this.OnUnSafeDispose( this.m_callbackTag ); 
					break; 
				case TaskState.Appearing: 
					this.OnUnSafeDispose( this.m_callbackTag ); 
					break; 
			} 
 
			this.callback = callback; 
			this.m_callbackTag = tag; 
			//设置自定义回传按钮的 Tag 值  
			if ( this.panel1.Controls.Count > 0 && tag != null ) 
			{ 
				foreach ( System.Windows.Forms.Control child in this.panel1.Controls ) 
				{ 
					child.Tag = tag; 
				} 
			} 
			this.m_unSafeDipose = unSafeDispose; 
		} 
		/// <summary> 
		/// 隐藏 
		/// </summary> 
		public new void Hide() 
		{ 
			if( this.CurrentTaskState != TaskState.Hidden ) 
			{ 
				this.timer1.Stop(); 
				this.CurrentTaskState = TaskState.Hidden; 
				base.Hide(); 
			} 
		} 
		/// <summary> 
		/// 单击超链接时发生的事件 
		/// </summary> 
		/// <param name="sender"></param> 
		/// <param name="e"></param> 
		private void linkContent_LinkClicked( object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e ) 
		{ 
			this.OnCallBack( this.m_callbackTag ); 
		} 
		/// <summary> 
		/// 触发回传事件 
		/// </summary> 
		/// <param name="tag"></param> 
		protected virtual void OnCallBack( System.Object tag ) 
		{ 
			if ( this.callback != null ) 
			{ 
				this.Hide(); 
				this.callback( tag ); 
			} 
		} 
		/// <summary> 
		/// 引发 
		/// </summary> 
		/// <param name="tag"></param> 
		protected virtual void OnUnSafeDispose( System.Object tag ) 
		{ 
			if ( this.m_unSafeDipose != null ) 
				this.m_unSafeDipose( tag ); 
		} 
		#endregion			 
		 
		#region Properties 
		/// <summary> 
		/// 获取或设置当前的显示状态 
		/// </summary> 
		protected TaskState CurrentTaskState 
		{ 
			get { return this.m_TaskState; } 
			set { this.m_TaskState = value; } 
		} 
		/// <summary> 
		/// 获取回传接钮列表 
		/// </summary> 
		private System.Collections.Hashtable CallBackButtons 
		{ 
			get  
			{ 
				if ( this.m_hashButtons == null ) 
					this.m_hashButtons = new System.Collections.Hashtable(); 
				return this.m_hashButtons; 
			} 
		} 
		/// <summary> 
		/// 获取或设置当前的回传按钮名称 
		/// </summary> 
		protected System.Object CurrentSkinButtonName 
		{ 
			get { return this.m_skinButtonName; } 
			set { this.m_skinButtonName = value; } 
		} 
		#endregion 
		 
		#region TaskState 
		/// <summary> 
		/// 定义一个任务通知器的状态枚举 
		/// </summary> 
		protected enum TaskState 
		{ 
			/// <summary> 
			/// 隐藏 
			/// </summary> 
			Hidden = 100, 
			/// <summary> 
			/// 可视 
			/// </summary> 
			Visible = 200, 
			/// <summary> 
			/// 刚刚显示，但还没显示完全 
			/// </summary> 
			Appearing = 300, 
			/// <summary> 
			/// 即将消失 
			/// </summary> 
			Disappearing 
		} 
		#endregion		 
 
		#region Delegates 
		/// <summary> 
		/// 定义一个回调委托 
		/// </summary> 
		public delegate void CallBackHandler( System.Object tag ); 
		/// <summary> 
		/// 定义一个因非正常关闭Popup的事件委托 
		/// </summary> 
		public delegate void UnSafeDiposeHandler( System.Object tag ); 
		#endregion 
	} 
}