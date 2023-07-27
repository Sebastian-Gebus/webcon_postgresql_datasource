using WebCon.WorkFlow.SDK.Common;
using WebCon.WorkFlow.SDK.ConfigAttributes;

namespace PostgreDataSource
{
    public class PostgreDataSourceConfig : PluginConfiguration
    {
        [ConfigEditableText(DisplayName = "PostgreSQL DB Host", DefaultText = "host", IsRequired = true)]
        public string DbHost { get; set; }

        [ConfigEditableText(DisplayName = "PostgreSQL DB Name", DefaultText = "db", IsRequired = true)]
        public string DbName { get; set; }

        [ConfigEditableText(DisplayName = "PostgreSQL DB User", DefaultText = "user", IsRequired = true)]
        public string DbUser { get; set; }

        [ConfigEditableText(DisplayName = "PostgreSQL DB Password", IsPasswordField = true, IsRequired = true)]
        public string DbPassword { get; set; }
    }
}