using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using MyJoints.DataAcceess.Context;

namespace MyJoints.Migrations
{
    [ContextType(typeof(MyJointDbContext))]
    partial class initial
    {
        public override string Id
        {
            get { return "20151024154315_initial"; }
        }
        
        public override string ProductVersion
        {
            get { return "7.0.0-beta5-13549"; }
        }
        
        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("SqlServer:DefaultSequenceName", "DefaultSequence")
                .Annotation("SqlServer:Sequence:.DefaultSequence", "'DefaultSequence', '', '1', '10', '', '', 'Int64', 'False'")
                .Annotation("SqlServer:ValueGeneration", "Sequence");
            
            builder.Entity("MyJoints.ViewModel.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .GenerateValueOnAdd()
                        .StoreGeneratedPattern(StoreGeneratedPattern.Identity);
                    
                    b.Property<DateTime>("Birthday");
                    
                    b.Property<string>("Email");
                    
                    b.Property<string>("FirstName");
                    
                    b.Property<string>("LastName");
                    
                    b.Property<string>("Login");
                    
                    b.Property<string>("Password");
                    
                    b.Key("Id");
                });
        }
    }
}
