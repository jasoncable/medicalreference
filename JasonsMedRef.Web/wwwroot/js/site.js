var medRefIndex = (function () {
    var my = {};

    my.setup = function () {
        //var rxList = new Bloodhound({
        //    datumTokenizer: function (datum) {
        //        return Bloodhound.tokenizers.whitespace(datum.value);
        //    },
        //    queryTokenizer: Bloodhound.tokenizers.whitespace,
        //    remote: {
        //        wildcard: '%QUERY',
        //        url: $('#courseTypeaheadUri').attr("data-uri") + '?searchTerm=%QUERY',
        //        filter: function (datum) {
        //            return $.map(datum, function (item) {
        //                return {
        //                    name: item.Name,
        //                    value: item.Id
        //                };
        //            });
        //        }
        //    }
        //});

        //rxList.initialize();

        //$('#rxSearch').typeahead(
        //    {
        //        hint: true,
        //        highlight: true,
        //        minLength: 3
        //    },
        //    {
        //        displayKey: 'name',
        //        source: rxList.ttAdapter(),
        //        limit: 25,
        //        templates: {
        //            empty: [
        //                "<div class='empty-message'>" +
        //                "No courses found matching the search criteria." +
        //                "</div>"
        //            ],
        //            suggestion: function (data) {
        //                return '<div class="col-md-12">' + data.name + ' [' + data.code + ']</div>';
        //            }
        //        }
        //    }
        //);

        //$('#rxSearch').bind('typeahead:select', function (ev, suggestion) {
        //    $("#rxSearchId").val(suggestion.value);
        //    var textbooks =
        //        $.ajax({
        //            method: 'POST',
        //            url: $('#textbooksForCourseUri').attr('data-uri'),
        //            data: { courseId: suggestion.value },
        //            success: function (data) {
        //                if (data.length > 0) {
        //                    for (var i = 0; i < data.length; i++)
        //                        $('#textbookList').append('<li data-id="' + data[i].Id + '">' + data[i].FullName + ' <span class="red-x">x</span</li>');
        //                }
        //                my.setupTextbookRemove();
        //            }
        //        });
        //});

        //$('#rxSearch').bind('typeahead:close', function (ev, suggestion) {
        //    if ($('.tt-suggestion').length === 0) {
        //        $("#rxSearchId").val("");
        //    }
        //    $(this).closest(".twitter-typeahead").find(".tt-menu").removeClass("tt-expanded");
        //});

        //$('#rxSearch').bind('typeahead:open', function (ev, suggestion) {
        //    setTimeout(expandTypeahead, 2500, $(this));
        //});

        //function expandTypeahead(id) {
        //    var tt = id.closest(".twitter-typeahead");
        //    if (tt.find(".tt-menu").hasClass("tt-open")) {
        //        tt.find(".tt-menu").addClass("tt-expanded");
        //    }
        //}
    };

    return my;
}());

var medRefRxSearch = (function () {
    var my = {};

    my.setup = function () {
        var datatable = $('#rxSearchTable').DataTable({
            searching: false
        });
    
        datatable.on('draw', function () {

            $('.rxDetailBtn').off('click').click(function() {
                window.location.href = $(this).attr('data-uri');
            });
        });

        datatable.draw();
        
    };

    return my;
}());

var medRefRxDetail = (function () {
    var my = {};

    my.setup = function () {
        $.ajax({
            url: '/Search/FulDetail',
            method: 'POST',
            data: { drugId: $('#drugId').val() },
            success: function (data) {
                $('#fulData').html(data);
            }
        });

        $.ajax({
            url: '/Search/SduDetail',
            method: 'POST',
            data: { drugId: $('#drugId').val() },
            success: function (data) {
                $('#sduData').html(data);
            }
        });

        $.ajax({
            url: '/Search/NadacDetail',
            method: 'POST',
            data: { drugId: $('#drugId').val() },
            success: function (data) {
                $('#nadacData').html(data);
            }
        });

        $.ajax({
            url: '/Search/PatentDetail',
            method: 'POST',
            data: { drugId: $('#drugId').val() },
            success: function (data) {
                $('#patentData').html(data);
            }
        });

        $.ajax({
            url: '/Search/PackageDetail',
            method: 'POST',
            data: { drugId: $('#drugId').val() },
            success: function (data) {
                $('#packageData').html(data);
            }
        });

        $.ajax({
            url: '/Search/ApplicationDetail',
            method: 'POST',
            data: { drugId: $('#drugId').val() },
            success: function (data) {
                $('#applicationData').html(data);
            }
        });

    };

    return my;
}());