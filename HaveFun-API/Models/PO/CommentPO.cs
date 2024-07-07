using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HaveFun_API.Models.PO;

/// <summary>
/// 留言
/// </summary>
public class Comment
{
    /// <summary>
    /// 編號
    /// </summary>
    [Key]
    public int ID { get; set; } = 0;

    /// <summary>
    /// 文章編號
    /// </summary>
    public int PostID { get; set; } = 0;

    /// <summary>
    /// 留言內容
    /// </summary>
	public string Content { get; set; } = "";

    /// <summary>
    /// 留言時間
    /// </summary>
    public DateTime CreateTime { get; set; } = DateTime.Now;

    /// <summary>
    /// 留言者
    /// </summary>
    public int CreateUser { get; set; } = 0;
}
