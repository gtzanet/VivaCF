
$(document).ready(function () {
    var picDivHeight = $(".row.categories").find(".col-md-6:first").height();
    $(".row.categories").find("div.col-md-6:nth-child(2)").first().css("height", picDivHeight);

    $("#MainContent_loadingImg").hide();
    $("#MainContent_savedImg").hide();
    $("#MainContent_AmountToBack").hide();
    $("#MainContent_BAmount").hide();
    $("#MainContent_PrID").hide();
    $("#MainContent_vivaButtonDiv").hide();
    //$("#MainContent_img").hide();
    //$("#MainContent_b64").hide();
});



$(document).on("click", ".dropdown-menu li", function () {

    var li_text = $(this).text();

    var arrow = '<span class="caret"></span>';

    var divButton = $(this).closest("div");

    var button = $(divButton).find("a:first");
    $(button).html(li_text + ' ' + arrow);

    var hiddenLabel = $(divButton).parent("div").find("span");
    $(hiddenLabel).addClass("appear");
    /*****************/


    var ul = $(this).closest("ul");

    if ($(ul).attr("id").indexOf("Category") > -1) {
        var category_id = $(this).attr("c");

        $("a#MainContent_Category").attr("category", category_id);

        $("a#MainContent_Subcategory").not("[category='" + category_id + "']").html("All" + ' ' + arrow);

        $("a#MainContent_Subcategory").attr("category", category_id);

        var subcategoriesli = $("ul#MainContent_Subcategory li");

        for (var index = 0; index < subcategoriesli.length; index++) {
            $(subcategoriesli).eq(index).show();
            if (category_id != undefined) {
                $(subcategoriesli).eq(index).not("[c='" + category_id + "']").hide();
            }
        }

    }
    if ($(ul).attr("id").indexOf("Subcategory") > -1) {
        var category_id = $(this).attr("c");
        var subcategory_id = $(this).attr("cb");

        $("a#MainContent_Category").attr("category", category_id);
        $("a#MainContent_Subcategory").attr("subCategory", subcategory_id);

        var CategoryButtonText = $("ul#MainContent_Category li[c='" + category_id + "']").text();

        if (CategoryButtonText != "") // den exei patisei to all
        {
            $("a#MainContent_Category").html(CategoryButtonText + ' ' + arrow);

            var subcategoriesli = $("ul#MainContent_Subcategory li");
            for (var index = 0; index < subcategoriesli.length; index++) {
                $(subcategoriesli).eq(index).show();
                if (category_id != undefined) {
                    $(subcategoriesli).eq(index).not("[c='" + category_id + "']").hide();
                }
            }
        } else {
            $("a#MainContent_Category").html("All" + ' ' + arrow);
        }


        var hiddenLabel = $("#MainContent_Category").parent("div").parent("div").find("span");
        $(hiddenLabel).addClass("appear");
    }

    /**************************/
    var allProjects = $("#MainContent_ShowProject div.projects");
    for (var index = 0; index < allProjects.length; index++) {
        $(allProjects).eq(index).show();
        if (category_id != undefined) {
            $(allProjects).eq(index).not("div[c='" + category_id + "']").hide();
            //
            if (subcategory_id != undefined) {
                $(allProjects).eq(index).not("[sb='" + subcategory_id + "']").hide();
            }
        }
    }


});

function loadProject(project_id) {
    window.location.href = "../Project/ProjectDetails.aspx?project_id=" + project_id;
}

$(document).on("change", "input", function () {
    $(this).addClass("changed");
});
$(document).on("change", "textarea", function () {
    $(this).addClass("changed");
});

function ResetFields() {

    $('input').each(function () {
        $(this).removeClass("changed");
    });

    $('textarea').each(function () {
        $(this).removeClass("changed");
    });
}

function callApiAndSaveProjDetails(projectID) {

    $("#MainContent_loadingImg").show();
    $("#MainContent_savedImg").hide();


    //e.preventDefault();
    var new_title = $("#MainContent_ProjectTitle").val();
    var new_descr = $("#MainContent_ProjectDescription").val();
    var new_Video = $("#MainContent_ProjectVideo").val();
    var new_Category = $("a#MainContent_Category").attr("category");
    var new_SubCategory = $("a#MainContent_Subcategory").attr("subcategory");
    var new_Image = $("#MainContent_b64").val();

    if (new_title.trim() != "" && new_descr.trim() != "") {

        setTimeout(function () {

            var settings = {

                "crossDomain": true,
                "type": "PUT",
                "contentType": "application/json; charset=utf-8",
                "async": false,
                "url": "http://localhost:60264/api/project/" + projectID,
                "dataType": "json",
                "headers": {
                    "project_id": projectID,
                    "content-type": "application/x-www-form-urlencoded",
                    "cache-control": "no-cache"
                },
                "data": {
                    "title": new_title
                    , "description": new_descr
                    , "video": new_Video
                    , "category": new_Category
                    , "subcategory": new_SubCategory
                    , "image": new_Image
                }
            }

            $.ajax(settings).done(function (response) {
                $("#MainContent_loadingImg").hide();
                $("#MainContent_savedImg").show();
                ResetFields();

                // freese window
                $("body").prepend("<div class=\"overlay\"></div>");

                $(".overlay").css({
                    "position": "absolute",
                    "width": $(document).width(),
                    "height": $(document).height(),
                    "z-index": 99999,
                }).fadeTo(0, 0.8);

                // redirect to the same page but not in edit mode
                var url = document.URL.substr(0, document.URL.indexOf('&'));
                window.location.replace(url);
                return true;
            });

            $.ajax(settings).fail(function (response) {
                $("#MainContent_loadingImg").hide();
                alert("fail");
                return false;
            });

        }, 300);
    }
    else {
        $("#MainContent_loadingImg").hide();
        alert("Project Title & Description are mandatory fields.");
        return false;
    }


}


$(document).on("click", ".col-md-3.rewards", function () {    
    $("#MainContent_AmountToBack").show();
    $("a#MainContent_backButton").html("Submit");
    $("#MainContent_AmountToBackTXT").val($(this).attr("minAmount"));
    $("#MainContent_backButton").click();
});


$(document).on("click", "#MainContent_backButton", function () {

    if ($("#MainContent_AmountToBack").is(":visible"))
    {
        var AmountInserted = $("#MainContent_AmountToBackTXT").val();

        if (AmountInserted == 0 || AmountInserted.trim() == "")
        {
            alert("Please insert a valid amount");
            return false;
        }
        $("#MainContent_backButton").hide();
        $("#MainContent_vivaButtonDiv").show();
        var project_id = getUrlParameter('project_id');
        // panos code here

        $('#MainContent_viva_button').html('  \
                    <form id="myform" method="post"> \
                        <button type="button" \
                            data-vp-sourcecode="Default" \
                            data-vp-publickey="y8YeFmNbbS7X6Nk0iHcKXZjocRR++l1yfFzmrtsdUb8=" \
                            data-vp-baseurl="https://demo.vivapayments.com" \
                            data-vp-lang="el" \
                            data-vp-amount="' + $("#MainContent_AmountToBackTXT").val() * 100 + '" \
                            data-vp-customeremail="" \
                            data-vp-customerfirstname = "" \
                            data-vp-customersurname = "" \
                            data-vp-merchantref="test merchant ref   aalalalalallal" \
                            data-vp-expandcard="true" \
                            data-vp-description="My product"> \
                        </button> \
                    </form>');

        $("#MainContent_BAmount").val($("#MainContent_AmountToBackTXT").val());
        $("#MainContent_PrID").val(project_id);


        var script = document.createElement('script');
        script.type = 'text/javascript';
        script.src = "https://demo.vivapayments.com/web/checkout/js";
        $("#MainContent_viva_button").append(script);



       // alert(project_id +  "You inserted " + AmountInserted + " \n Redirect to Viva");


    }
    else {
        
        $("#MainContent_AmountToBack").show();
        $("a#MainContent_backButton").html("Submit");
    }
    return false;
});


$(document).on("click", ".col-md-3.rewards", function () {
    $("#MainContent_AmountToBack").show();
    $("a#MainContent_backButton").html("Submit");
    $("#MainContent_AmountToBackTXT").val($(this).attr("minAmount"));
    $("#MainContent_backButton").click();
});



$(document).on("change", "#MainContent_photo-upload", function () {

    if (this.files && this.files[0]) {
        
        var FR = new FileReader();

        FR.onload = function (e) {
            var source = e.target.result;
            $("#MainContent_img").attr("src", source);
            
            $("#MainContent_b64").val(source.substr(source.indexOf(',') + 1, source.length));
        };
        FR.readAsDataURL(this.files[0]);
    }
});






var getUrlParameter = function getUrlParameter(sParam) {
    var sPageURL = decodeURIComponent(window.location.search.substring(1)),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : sParameterName[1];
        }
    }
};