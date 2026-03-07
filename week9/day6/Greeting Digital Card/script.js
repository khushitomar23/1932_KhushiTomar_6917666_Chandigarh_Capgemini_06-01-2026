function showSurprise()
{
let msg = document.getElementById("surprise");

if(msg.style.display === "none" || msg.style.display === "")
{
msg.style.display = "block";
}
else
{
msg.style.display = "none";
}
}