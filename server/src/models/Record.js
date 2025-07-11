class Record {
    constructor(data) {
        this.id = data.id,
        this.user_id = data.user_id,
        this.username1 = data.username1,
        this.username2 = data.username2,
        this.map_id = data.map_id,
        this.time_record = data.time_record,
        this.created_at = data.created_at
    }
    
    static validate(data) {
        const errors = [];
        if (!data.user_id) errors.push('user_id is required');
        if (!data.username1) errors.push('username1 is required');
        if (!data.username2) errors.push('username2 is required');
        if (!data.map_id) errors.push('map_id is required');
        if (!data.time_record) errors.push('time_record is required');
        return errors;
    }
}

module.exports = Record;