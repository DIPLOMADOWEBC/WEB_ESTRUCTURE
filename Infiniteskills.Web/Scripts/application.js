// Write your Javascript code.
$(document).ready(function () {
    $.jgrid.defaults.responsive = true;
    $.jgrid.defaults.styleUI = 'Bootstrap';
    $.jgrid.styleUI.Bootstrap.base.rowTable = "table table-bordered table-striped";
    $.fn.modal.Constructor.prototype.enforceFocus = function () { };

    $("#sidebar").mCustomScrollbar({
        theme: "minimal"
    });

    $('#sidebarCollapse').on('click', function () {
        $('#sidebar, #content').toggleClass('active');
        $('.collapse.in').toggleClass('in');
        $('a[aria-expanded=true]').attr('aria-expanded', 'false');
        $(window).bind('resize', function () {
            $.jgrid.defaults.width = $("#panel").width();
        }).trigger('resize');
    });

    //$(document).on('blur', "input[type=text]", function () {
    //    $(this).val(function (_, val) {
    //        return val.toUpperCase();
    //    });
    //});
});

function controllerPostAction(url, data, controlContent, showLoading, hideLoading, functionOnSucess) {
    controllerGenericAction("POST", url, data, "html", controlContent, showLoading, hideLoading, functionOnSucess);
}

function controllerGetAction(url, data, controlContent, showLoading, hideLoading, functionOnSucess) {
    controllerGenericAction("GET", url, data, "html", controlContent, showLoading, hideLoading, functionOnSucess);
}

function controllerSaveAction(url, data, showLoading, hideLoading, functionOnSucess) {
    controllerGenericAction("POST", url, data, "json", "", showLoading, hideLoading, functionOnSucess);
}

function controllerGenericAction(type, url, data, dataType, controlContent, showLoading, hideLoading, functionOnSucess) {
    $.ajax({
        beforeSend: function () {
            if (showLoading == true) {
                waitingDialog.show('Cargando... por favor espere.');
            }

        },
        complete: function () {
            if (hideLoading == true) {
                waitingDialog.hide();
            }
        },
        type: type,
        contentType: "application/json; charset=utf-8",
        url: url,
        data: data,
        dataType: dataType,
        success: function (response, textStatus, jqXHR) {
            if (controlContent != "")
                $("#" + controlContent).html(response);

            if (typeof functionOnSucess == 'function')
                functionOnSucess(response);
        },
        error: function (xhr, status, error) {


        }
    });
}

function controllerSaveResponse(url, data, showLoading, hideLoading, functionOnSucess) {
    $.ajax({
        type: 'POST',
        beforeSend: function () {
            if (showLoading == true) {
                waitingDialog.show('Cargando... por favor espere.');
            }
        },
        complete: function () {
            if (hideLoading == true) {
                waitingDialog.hide();
            }
        },
        url: url,
        data: data,
        dataType: 'json',
        cache: false,
    }).done(function (data, textStatus, jqXHR) {
        if (typeof functionOnSucess == 'function')
            functionOnSucess(data);

    }).fail(function (jqXHR, textStatus, errorThrown) {

    });

};

function MsgAlert(key, message) {
    switch (key) {
        case 1:
            $.notify({
                icon: 'glyphicon glyphicon-ok-sign',
                title: ' ',
                message: message
            }, { type: 'success', z_index: 2000 });
            break;
        case 2:
            $.notify({
                icon: 'glyphicon glyphicon-question-sign',
                title: ' ',
                message: message
            }, { type: 'info', z_index: 2000 });
            break;
        case 3:
            $.notify({
                icon: 'glyphicon glyphicon-warning-sign',
                title: ' ',
                message: message
            }, { type: 'warning', z_index: 2000 });
            break;
        case 4:
            $.notify({
                icon: 'glyphicon glyphicon-remove-sign',
                title: ' ',
                message: message
            }, { type: 'danger', z_index: 2000 });
            break;
    }
    return false;

}

$.fn.serializeObject = function () {
    var o = {};
    var a;
    if ($(this).is("div"))
        a = this.find("input,select,textarea").serializeArray();
    else
        a = this.serializeArray();


    $.each(a, function () {
        if (o[this.name] !== undefined) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            if ($('#' + this.name).is(":checkbox")) {
                o[this.name] = (this.value == 'on' ? '1' : '0');
            }
            else
                o[this.name] = this.value || '';
        }
    });
    return o;
};



function getGridSelectedRowId(gridName) {
    var rowid = $("#" + gridName).jqGrid('getGridParam', 'selrow');

    return rowid;
};

function getGridSelectedRow(gridName) {
    var rowid = getGridSelectedRowId(gridName);
    if (rowid == null)
        return [];
    return getGridRow(gridName, rowid);
};

function getGridRow(gridName, rowid) {
    var row = $("#" + gridName).jqGrid('getRowData', rowid);
    return row;
};

function gridRowCount(gridName) {
    var rowCount = $("#" + gridName).jqGrid('getGridParam', 'records');
    return rowCount;
}

function gridNewRowId(gridName) {
    var rowCount = gridRowCount(gridName);
    var index = 0;

    if (rowCount != 0)
        index = $("#" + gridName).jqGrid('getDataIDs')[rowCount - 1];

    return parseInt(index) + 1;
}
function gridDataIDs(gridName) {
    var idList = $("#" + gridName).jqGrid('getDataIDs');
    return idList;
};

function stringToDecimal(string) {
    return parseFloat(string.toString().trim().replace(/,/g, "").replace(/ /g, ""));
}

function round(value, decimals) {
    return Number(Math.round(value + 'e' + decimals) + 'e-' + decimals);
};

function multiplicar(value1, value2) {

    var int1 = parseInt(value1.toString().replace(".", ""));
    var int2 = parseInt(value2.toString().replace(".", ""));
    var sum = int1 * int2;
    var numDecimales = (value1.toString().split('.').length > 1 ? value1.toString().split('.')[1].length : 0) + (value2.toString().split('.').length > 1 ? value2.toString().split('.')[1].length : 0);
    if (numDecimales == 0)
        return sum;

    return parseFloat(sum.toString().substr(0, sum.toString().length - numDecimales) + "." + sum.toString().substr(-1 * numDecimales));

};

function isEmpty(obj) {
    var hasOwnProperty = Object.prototype.hasOwnProperty;
    // null and undefined are "empty"
    if (obj == null) return true;

    // Assume if it has a length property with a non-zero value
    // that that property is correct.
    if (obj.length > 0) return false;
    if (obj.length === 0) return true;

    // Otherwise, does it have any properties of its own?
    // Note that this doesn't handle
    // toString and valueOf enumeration bugs in IE < 9
    for (var key in obj) {
        if (hasOwnProperty.call(obj, key)) return false;
    }

    return true;
};


$.fn.addItems = function (data) {
    return this.each(function () {
        var list = this;
        $.each(data, function (index, itemData) {
            var option = new Option(itemData.Text, itemData.Value);
            list.add(option);
        });

    });
};


function isEmptyElement(id, message) {
    var ctl = document.getElementById(id);
    var blnEmpty = false;

    if (ctl == null) {
        var mesage = 'El control ' + id + ' no existe';
        MsgAlert(4, mesage);
        return true;
    }
    switch (ctl.type) {
        case 'text':
        case 'password':
        case 'textarea':
        case 'hidden':
        case 'select-one':
            if (ctl.value == '') {
                blnEmpty = true;
                break;
            }
            else {
                if (ctl.classList.contains("inputnumeric-element")) {
                    var dec = parseFloat(ctl.value);
                    if (dec == null) {
                        blnEmpty = true;
                        break;
                    }
                    else {
                        if (dec == 0) {
                            blnEmpty = true;
                            break;
                        }
                        else {
                            blnEmpty = false;
                            break;
                        }
                    }
                    break;
                }
                else {
                    blnEmpty = false;
                }
            }
            break;
    }

    if (blnEmpty && message != '') {
        MsgAlert(3, message);
        ctl.focus();
    }
    return blnEmpty;
};


/**
 * Module for displaying "Waiting for..." dialog using Bootstrap
 *
 * @author Eugene Maslovich <ehpc@em42.ru>
 */

var waitingDialog = waitingDialog || (function ($) {
    'use strict';

    // Creating modal dialog's DOM
    var $dialog = $(
        '<div class="modal fade" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-hidden="true" style="padding-top:15%; overflow-y:visible;">' +
        '<div class="modal-dialog modal-m">' +
        '<div class="modal-content">' +
        '<div class="modal-header"><h3 style="margin:0;"></h3></div>' +
        '<div class="modal-body">' +
        '<div class="progress progress-striped active" style="margin-bottom:0;"><div class="progress-bar" style="width: 100%"></div></div>' +
        '</div>' +
        '</div></div></div>');

    return {
        /**
         * Opens our dialog
         * @param message Custom message
         * @param options Custom options:
         * 				  options.dialogSize - bootstrap postfix for dialog size, e.g. "sm", "m";
         * 				  options.progressType - bootstrap postfix for progress bar type, e.g. "success", "warning".
         */
        show: function (message, options) {
            // Assigning defaults
            if (typeof options === 'undefined') {
                options = {};
            }
            if (typeof message === 'undefined') {
                message = 'Loading';
            }
            var settings = $.extend({
                dialogSize: 'm',
                progressType: '',
                onHide: null // This callback runs after the dialog was hidden
            }, options);

            // Configuring dialog
            $dialog.find('.modal-dialog').attr('class', 'modal-dialog').addClass('modal-' + settings.dialogSize);
            $dialog.find('.progress-bar').attr('class', 'progress-bar');
            if (settings.progressType) {
                $dialog.find('.progress-bar').addClass('progress-bar-' + settings.progressType);
            }
            $dialog.find('h3').text(message);
            // Adding callbacks
            if (typeof settings.onHide === 'function') {
                $dialog.off('hidden.bs.modal').on('hidden.bs.modal', function (e) {
                    settings.onHide.call($dialog);
                });
            }
            // Opening dialog
            $dialog.modal();
        },
        /**
         * Closes dialog
         */
        hide: function () {
            $dialog.modal('hide');
        }
    };

})(jQuery);

$.fn.menuBar = function (options) {

    var defaults = {
        button: null,
        disabled: false
    };

    var settings = $.extend(defaults, options);

    return this.each(function () {

        var self = $(this);
        if (settings.button) {
            var ctl = $("#" + self[0].id + '_' + settings.button);
            ctl.attr("disabled", settings.disabled);
            var imgTags = $('img', ctl).each(function () {
                var urlRelative = $(this).attr("src");
                var urlAbsolute = '';
                if (settings.disabled)
                    urlAbsolute = urlRelative.replace("/enabled/", "/disabled/");
                else
                    urlAbsolute = urlRelative.replace("/disabled/", "/enabled/");
                $(this).attr("src", urlAbsolute);
            });
        }

    });
};

function getHeightForResize(ajuste) {

    var divHp = document.getElementById('bandeja');
    var divTp = document.getElementById('panel');
    var divMb = document.getElementById('MenuBar');
    var divSP = document.getElementById('seachPanel');
    var divCh = document.getElementById('ContentHeader');

    var intHeight = 0;

    if (divHp)
        intHeight += divHp.offsetHeight;

    if (divTp)
        intHeight += divTp.offsetHeight;

    if (divMb)
        intHeight += divMb.offsetHeight;

    if (divSP)
        intHeight += divSP.offsetHeight;

    if (divCh)
        intHeight += divCh.offsetHeight;

    var intHDif = $(document).height() - (intHeight + (ajuste || 0));
    return intHDif;
};