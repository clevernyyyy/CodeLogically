$(function () {
    AddTreeView();
})

function AddTreeView() {
    $("#tree").treeview({
        collapsed: true,
        animated: "fast",
        control: "#sidetreecontrol",
        prerendered: true,
        persist: "location"
    });
    $("#sidetree ul li:last-child").filter(".expandable").addClass("lastExpandable");
    $("#sidetree ul li:last-child").filter(".collapsible").addClass("lastcollapsible");
    $("input[id$='chkCoverage']").click(function () { toggleCoverage(this.id); });
}

function toggleCoverage(id) {
    var chk = $('#' + id);
    var prev = chk.prev();
    if (prev.length == 0)
      prev = $('#' + id.replace('chkCoverage','div'));
    if ((prev.hasClass('expandable-hitarea') && chk.prop('checked')) ||
                (prev.hasClass('collapsible-hitarea') && !chk.prop('checked'))) {
        prev.click();
    }
    return true;
}