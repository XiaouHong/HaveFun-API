using HaveFun_API.Models.PO;
using Microsoft.EntityFrameworkCore;

namespace HaveFun_API.Schafold
{
	/// <summary>
	/// Context
	/// </summary>
    public class HaveFunContext : DbContext
	{
		/// <summary>
		/// 建構子
		/// </summary>
		public HaveFunContext(DbContextOptions<HaveFunContext> options) : base(options)
		{
			Database.SetCommandTimeout(150 * 1000);
		}

		/// <summary>
		/// 模型創建
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AddressPO>().ToTable("Address");
			modelBuilder.Entity<AttractionPO>().ToTable("Attraction");
			modelBuilder.Entity<AuthorityPO>().ToTable("Authority");
			modelBuilder.Entity<AuthorityBelongPO>().ToTable("AuthorityBelong");
			modelBuilder.Entity<AuthorityFunctionPO>().ToTable("AuthorityFunction");
			modelBuilder.Entity<AuthorityGroupPO>().ToTable("AuthorityGroup");
			modelBuilder.Entity<AuthoritySystemPO>().ToTable("AuthoritySystem");
			modelBuilder.Entity<Comment>().ToTable("Comments");
			modelBuilder.Entity<Models.PO.FilePO>().ToTable("Files");
			modelBuilder.Entity<LikePO>().ToTable("Likes");
			modelBuilder.Entity<MemberPO>().ToTable("Member");
			modelBuilder.Entity<MemberShipPO>().ToTable("MemberShip");
			modelBuilder.Entity<PlanningPO>().ToTable("Planning");
			modelBuilder.Entity<PostPO>().ToTable("Posts");
			modelBuilder.Entity<SchedulePO>().ToTable("Schedule");
			modelBuilder.Entity<ScheduleVersionPO>().ToTable("ScheduleVersions");
		}

		/// <summary>
		/// 地址
		/// </summary>
		public DbSet<AddressPO> Address { get; set; }

		/// <summary>
		/// 景點
		/// </summary>
		public DbSet<AttractionPO> Attraction { get; set; }

		/// <summary>
		/// 權限
		/// </summary>
		public DbSet<AuthorityPO> Authority { get; set; }

		/// <summary>
		/// 權限歸屬
		/// </summary>
		public DbSet<AuthorityBelongPO> AuthorityBelong { get; set; }

		/// <summary>
		/// 權限方法
		/// </summary>
		public DbSet<AuthorityFunctionPO> AuthorityFunction { get; set; }

		/// <summary>
		/// 權限群組
		/// </summary>
		public DbSet<AuthorityGroupPO> AuthorityGroup { get; set; }

		/// <summary>
		/// 權限系統
		/// </summary>
		public DbSet<AuthoritySystemPO> AuthoritySystem { get; set; }

		/// <summary>
		/// 檔案
		/// </summary>
		public DbSet<Models.PO.FilePO> File { get; set; }

		/// <summary>
		/// 按讚
		/// </summary>
		public DbSet<LikePO> Like { get; set; }

		/// <summary>
		/// 成員
		/// </summary>
		public DbSet<MemberPO> Member { get; set; }

		/// <summary>
		/// 交友
		/// </summary>
		public DbSet<MemberShipPO> MemberShip { get; set; }

		/// <summary>
		/// 規劃
		/// </summary>
		public DbSet<PlanningPO> Planning { get; set; }

		/// <summary>
		/// 文章
		/// </summary>
		public DbSet<PostPO> Post { get; set; }

		/// <summary>
		/// 行程表
		/// </summary>
		public DbSet<SchedulePO> Schedule { get; set; }

		/// <summary>
		/// 行程表版本
		/// </summary>
		public DbSet<ScheduleVersionPO> ScheduleVersion { get; set; }
	}
}
