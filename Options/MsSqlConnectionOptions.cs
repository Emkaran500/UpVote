using System.Text;

namespace UpVote.Options;

public class MsSqlConnectionOptions
{
    public string? Database { get; set; }
    public string? Server { get; set; }
    public string? UserId { get; set; }
    public string? Password { get; set; }
    public string? Trusted_Connection { get; set; }
    public string? Options { get; set; }

    public string ConnectionString {
        get {
            ArgumentException.ThrowIfNullOrEmpty(Database);
            ArgumentException.ThrowIfNullOrEmpty(Server);

            StringBuilder connectionString = new StringBuilder();

            if (string.IsNullOrWhiteSpace(this.UserId) == false && string.IsNullOrWhiteSpace(this.Password) == false)
            {
                connectionString.Append($"Database={this.Database};Server={this.Server};User Id={this.UserId};Password={this.Password};");

                if(string.IsNullOrWhiteSpace(this.Trusted_Connection) == false)
                {
                    connectionString.Append($"Trusted_Connection={this.Trusted_Connection};");
                }
            }
            else if (string.IsNullOrWhiteSpace(this.Trusted_Connection) == false)
            {
                connectionString.Append($"Database={this.Database};Server={this.Server};Trusted_Connection={this.Trusted_Connection};");
            }
            else
            {
                throw new Exception("Not enough credentials to access Db!");
            }

            if (string.IsNullOrWhiteSpace(this.Options) == false)
            {
                connectionString.Append(Options);
            }

            
            return connectionString.ToString();
        }
    }
}