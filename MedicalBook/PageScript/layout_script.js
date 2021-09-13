



search.oninput = function () {
    var recordId = search.value;
    $.getJSON("/Home/ProductSearch",
        {
            search: recordId
        },
        function (data) {
            $("#list-search").empty();
            $.each(data, function (i) {
                var list = ' <li data-productid="28740">\
                                <a href = "#" >\
                                    <p>\
                                        <span class="search-image"><img src="'+ data[i].p_image +'" class="search-result-thumbnail"></span>\
                                            <span class="search-content">' + data[i].p_name + '</span>\
                                            <span class="search-price">' + data[i].p_price + '</span>\
                                    </p>\
                                </a>\
                            </li >';
                $("#search_list").append(list);
                $("#search_list").show();
            });
        });
};

$(document).ready(function () {
    GetMenu();
    GetCategory();
    GetHomeMenu();
});


function GetHomeMenu() {
    $.getJSON("/Menus/HomeMenu",
        {

        },
        function (data) {

            var li1 = '<li class="active">\
                         <a href = "index.html" > Home</a>\
                       </li>';
            var li2 = '';

            $("#topmenu").empty();
            var dat = data.menuViewModels;
            $.each(dat, function (i) {

                var ul1 = '<li>\
                            <a href = "#">' + dat[i].m_name + '</a>\
                            <ul class="megamenu">\
                                <li>\
                                    <h4 class="menu-title">Clinical Science</h4>\
                                    <ul>';
                var ul2 = '';
                var dat1 = dat[i].subMenuViewModels;
                $.each(dat1, function (j) {
                    ul2 += '<li><a href="#">' + dat1[j].sm1_name + '</a></li>';
                });             


                var ul3  =         '</ul>\
                                </li>\
                            </ul>\
                        </li>';
                li2 += ul1 + ul2 + ul3;
            });

            var li3 = '<li>\
                            <a href = "about-us.html" > MedicalBook Quick Tour</a>\
                            <ul style="min-width: 28.5rem;">\
                                <li><a href="#">Explore Books</a></li>\
                                <li><a href="#">About us</a></li>\
                                <li><a href="#">Blog</a></li>\
                                <li><a href="#">Contact us</a></li>\
                            </ul>\
                        </li >';

            var list = li1 + li2 + li3;

            $("#topmenu").append(list);
        });
}


function GetCategory() {
    $.getJSON("/Product/GetCategory",
        {

        },
        function (data) {
            $("#category").empty();
            var dat = data.productMainCategoryViewModels;
            $("#category").append('<option value="">All Category</option>');
            $.each(dat, function (i) {

                var list = '<option value="">' + dat[i].mpc_name +'</option>';
                $("#category").append(list);
            });
});
}

function GetMenu() {
    $.getJSON("/Product/GetMenu",
        {
          
        },
        function (data) {
            $("#menu_item").empty();
            var dat = data.productMainCategoryViewModels;
            $.each(dat, function (i) {
        var list = '<li>\
            <a href = "shop-fullwidth-banner.html" >\
                <i class="w-icon-orders"></i>'+ dat[i].mpc_name +'\
                                            </a >\
            <ul class="megamenu" style="min-width: 26.5rem;">\
                <li>\
                    <h4 class="menu-title">'+ dat[i].mpc_name +'</h4>\
                    <hr class="divider">\
                        <ul>';
                var list1 = "";
                var dat1 = dat[i].productCategoryViews;
                $.each(dat1, function (j) {
                    list1 += '<li><a href="Product/ProductCategoryView?catid=' + dat1[j].pc_id + '">' + dat1[j].pc_name +'</a></li>';
                });
                var list2 = "</ul>\
                                                </li>\
                                            </ul>\
                                        </li>";
                var data = list + list1 + list2;

                $("#menu_item").append(data);
       
         });
        });




}