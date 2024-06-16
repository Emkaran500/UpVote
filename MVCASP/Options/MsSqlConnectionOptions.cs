using System.Text;
using UpVote.Options.Connections.Base;

namespace ConfigurationApp.Options.Connections;

public class MsSqlConnectionOptions : IConnectionOptions
{
    public string? Database { get; set; }
    public string? Server { get; set; }
    public string? UserId { get; set; }
    public string? Password { get; set; }
    public string? TrustServerCertificate { get; set; }

    public string ConnectionString {
        get {
            ArgumentException.ThrowIfNullOrEmpty(Database);
            ArgumentException.ThrowIfNullOrEmpty(Server);

            StringBuilder connectionString = new StringBuilder();

            if (string.IsNullOrWhiteSpace(this.UserId) == false && string.IsNullOrWhiteSpace(this.Password) == false)
            {
                connectionString.Append($"Database={this.Database};Server={this.Server};User Id={this.UserId};Password={this.Password};");

                if(string.IsNullOrWhiteSpace(this.TrustServerCertificate) == false)
                {
                    connectionString.Append($"TrustServerCertificate={this.TrustServerCertificate};");
                }
            }
            else if (string.IsNullOrWhiteSpace(this.TrustServerCertificate) == false)
            {
                connectionString.Append($"Database={this.Database};Server={this.Server};TrustServerCertificate={this.TrustServerCertificate};");
            }
            else
            {
                throw new Exception("Not enough credentials to access Db!");
            }

            
            return connectionString.ToString();
        }
    }
}