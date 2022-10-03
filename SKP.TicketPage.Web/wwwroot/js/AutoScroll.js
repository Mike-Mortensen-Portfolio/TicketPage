$(".cust-monitor-container").scrollTop(0);
for (var i = 0; i < 5; i++) {
    $(".cust-monitor-container").animate({ scrollTop: $(document).height() }, 30000, 0, 0);
    $(".cust-monitor-container").animate({ scrollTop: 0 }, 30000, 0);
}