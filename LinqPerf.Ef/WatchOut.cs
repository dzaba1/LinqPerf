using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinqPerf.Ef
{
    public static class WatchOut
    {
        public static async Task ForEnumerableCastingAsync(bool cast = true)
        {
            try
            {
                var log = new DbLogger();
                using (var context = await MyDbContext.CreateAsync(log).ConfigureAwait(false))
                {
                    await InitDataAsync(context).ConfigureAwait(false);

                    log.LoggingEnabled = true;

                    var query = context.MyModel;

                    IEnumerable<Model> processed;
                    if (cast)
                    {
                        processed = WrongOperation(query);
                    }
                    else
                    {
                        processed = CorrectOperation(query);
                    }

                    foreach (var item in processed)
                    {
                        Console.WriteLine($"Id: {item.Id}; Value: {item.Value}");
                    }
                    log.LoggingEnabled = false;
                }
            }
            finally
            {
                MyDbContext.DeleteDb();
            }
        }

        private static IEnumerable<Model> WrongOperation(IEnumerable<Model> model)
        {
            return model.Where(m => m.Id > 90);
        }

        private static IEnumerable<Model> CorrectOperation(IQueryable<Model> model)
        {
            return model.Where(m => m.Id > 90);
        }

        private static async Task InitDataAsync(MyDbContext context)
        {
            for (int i = 0; i < 100; i++)
            {
                context.MyModel.Add(new Model
                {
                    Value = i.ToString()
                });
            }
            await context.SaveChangesAsync()
                .ConfigureAwait(false);
        }
    }
}
