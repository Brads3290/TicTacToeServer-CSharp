using Newtonsoft.Json;

namespace TicTacToe.Api.Common;

public class JsonRepositoryBase {

    protected async Task SaveFile<T>(string filename, T store) {
        var json = JsonConvert.SerializeObject(store);
        await File.WriteAllTextAsync(filename, json);
    }

    protected async Task<T> LoadFile<T>(string filename) where T : new() {
        if (!await Task.Run(() => File.Exists(filename))) {
            return new();
        }

        var json = await File.ReadAllTextAsync(filename);
        return JsonConvert.DeserializeObject<T>(json) ?? new();
    }

}