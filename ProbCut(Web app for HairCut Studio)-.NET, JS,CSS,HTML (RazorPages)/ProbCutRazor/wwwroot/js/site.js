// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
// ----------------------------------------------------------------------------------

$(document).ready(function ()
{
    // reading language cookie
    var reg = RegExp("lang=([^;]+)");
    var value = reg.exec(document.cookie);

    if (value != null)
    {
        if (value[1] == "en")
        {
            setLangEN();
        }
        else if (value[1] == "sr")
        {
            setLangSR();
        }
    }
    else
        setLangEN();

    // setting a navbar-item active
    var url = window.location;
    $('.navbar').find('.active').removeClass('active');
    $('.navbar li a').each(function ()
    {
        if (this.href == url)
        {
            $(this).parent().addClass('navbarActiveBorder');
        }
    });
})

function LangChanged(lang)
{
    var checkBoxEn = document.getElementById("langCheckboxEN");
    var checkBoxSr = document.getElementById("langCheckboxSR");
    if ((lang == "en") && (checkBoxEn.style.display != "block"))
    {
        setLangEN();

        // writing language cookie
        var expirationDate = new Date();
        expirationDate.setMonth(expirationDate.getMonth() + 1);
        document.cookie = "lang=en;path=/;expires=" + expirationDate.toUTCString();

        location.reload();
    }
    else if ((lang == "sr") && (checkBoxSr.style.display != "block"))
    {
        setLangSR();

        // writing language cookie
        var expirationDate = new Date();
        expirationDate.setMonth(expirationDate.getMonth() + 1);
        document.cookie = "lang=sr;path=/;expires=" + expirationDate.toUTCString();

        location.reload();
    }
}

function setLangEN()
{
    document.getElementById("langCheckboxEN").style.display = "block";
    document.getElementById("langCheckboxSR").style.display = "none";
}

function setLangSR()
{
    document.getElementById("langCheckboxEN").style.display = "none";
    document.getElementById("langCheckboxSR").style.display = "block";
}