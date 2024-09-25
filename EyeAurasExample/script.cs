// Кому звоним - пишем, работает только с @username
var username = "@username";

var telegram = new TelegramApiClient();

// Пример использования для отправки текста
var (isSuccessText, responseText) = await telegram.SendTextMessageAsync(username, "hi");
if (isSuccessText)
{
    Log.Info($"Message sent successfully: {responseText}");
}
else
{
    Log.Error($"Failed to send message: {responseText}");
}

// Пример использования для отправки фотографии
var (isSuccessPhoto, responsePhoto) = await telegram.SendPhotoAsync(username, "https://eyeauras.net/assets/img/mainIcon.webp", "This is a caption");
if (isSuccessPhoto)
{
    Log.Info($"Photo sent successfully: {responsePhoto}");
}
else
{
    Log.Error($"Failed to send photo: {responsePhoto}");
}

// Пример использования для совершения звонка
var (isSuccessCall, responseCall) = await telegram.MakeCallAsync(username);
if (isSuccessCall)
{
    Log.Info($"Call initiated successfully: {responseCall}");
}
else
{
    Log.Error($"Failed to initiate call: {responseCall}");
}

// Пример использования для отправки текста и выполнения звонка
var (isSuccessTextAndCall, responseTextAndCall) = await telegram.SendTextAndCallAsync(username, "Hello, this is a <b>message</b> with a call");
if (isSuccessTextAndCall)
{
    Log.Info($"Message with call sent successfully: {responseTextAndCall}");
}
else
{
    Log.Error($"Failed to send message with call: {responseTextAndCall}");
}
