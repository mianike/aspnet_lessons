namespace CarSpecificationsAPI.Startup;

public static class ApplicationPipeline
{
    public static void InitializePipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

    }
}
