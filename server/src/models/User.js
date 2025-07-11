class User {
    constructor(data) {
        this.id = data.id,
        this.id_google = data.id_google
        this.username1 = data.username1,
        this.username2 = data.username2,
        this.created_at = data.created_at
    }
    
    static validate(data) {
        const errors = [];
        if (!data.id_google) errors.push('id_google is required');
        return errors;
    }
}