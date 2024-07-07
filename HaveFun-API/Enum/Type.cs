using System.ComponentModel;

namespace HaveFun_API.Enum
{
	/// <summary>
	/// 景點類別
	/// </summary>
	public enum AttractionType
	{
		/// <summary>
		/// 未知
		/// </summary>
		[Description("未知")]
		Unknow = 0,
		/// <summary>
		/// 景點
		/// </summary>
		[Description("景點")]
		Site = 1,
		/// <summary>
		/// 餐廳
		/// </summary>
		[Description("餐廳")]
		Restaurant = 2,
		/// <summary>
		/// 飯店
		/// </summary>
		[Description("飯店")]
		Hotel = 3
	}

	/// <summary>
	/// 權限類別
	/// </summary>
	public enum AuthorityType
	{
		/// <summary>
		/// 未知
		/// </summary>
		[Description("未知")]
		Unknow = 0,
		/// <summary>
		/// 景點
		/// </summary>
		[Description("禁用")]
		Disable = 1,
		/// <summary>
		/// 一般
		/// </summary>
		[Description("一般")]
		Normal = 2,
		/// <summary>
		/// 訂閱者
		/// </summary>
		[Description("訂閱者")]
		Subscription = 3
	}

	/// <summary>
	/// 關係類別
	/// </summary>
	public enum ShipType
	{
		/// <summary>
		/// 未知
		/// </summary>
		[Description("未知")]
		Unknow = 0,
		/// <summary>
		/// 拒絕邀請
		/// </summary>
		[Description("拒絕邀請")]
		Reject = 1,
		/// <summary>
		/// 邀請請求
		/// </summary>
		[Description("邀請請求")]
		Request = 2,
		/// <summary>
		/// 朋友
		/// </summary>
		[Description("朋友")]
		Friend = 3
	}

	/// <summary>
	/// 目標類別
	/// </summary>
	public enum TargetType
	{
		/// <summary>
		/// 未知
		/// </summary>
		[Description("未知")]
		Unknow = 0,
		/// <summary>
		/// 成員
		/// </summary>
		[Description("成員")]
		Member = 1,
		/// <summary>
		/// 群組
		/// </summary>
		[Description("群組")]
		Group = 2,
	}

	/// <summary>
	/// 文章類別
	/// </summary>
	public enum PostType
	{
		/// <summary>
		/// 未知
		/// </summary>
		[Description("未知")]
		Unknow = 0,
		/// <summary>
		/// 請益
		/// </summary>
		[Description("請益")]
		Question = 1,
		/// <summary>
		/// 心得
		/// </summary>
		[Description("心得")]
		Review = 2,
	}

	/// <summary>
	/// 按讚類別
	/// </summary>
	public enum LikeType
	{
		/// <summary>
		/// 未知
		/// </summary>
		[Description("未知")]
		Unknow = 0,
		/// <summary>
		/// 文章
		/// </summary>
		[Description("文章")]
		Question = 1,
		/// <summary>
		/// 留言
		/// </summary>
		[Description("留言")]
		Review = 2,
	}

	/// <summary>
	/// 結果種類
	/// </summary>
	public enum ResultCodeType
	{
		/// <summary>
		/// 未知
		/// </summary>
		[Description("未知")]
		Unknow = 0,
		/// <summary>
		/// 成功
		/// </summary>
		[Description("成功")]
		Success = 1,
		/// <summary>
		/// 參數錯誤
		/// </summary>
		[Description("參數錯誤")]
		ErrorParameter = 2,
		/// <summary>
		/// 憑證過期
		/// </summary>
		[Description("憑證過期")]
		Invalid = 3,
		/// <summary>
		/// 失敗
		/// </summary>
		[Description("失敗")]
		Fail = 4
	}
}
